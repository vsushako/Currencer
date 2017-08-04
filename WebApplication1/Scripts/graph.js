
(function($) {

    var context,
        points = [],
        methods = {
            init: function(options) {
                debugger;
                var defaults = {
                        x_axis_name: "",
                        y_axis_name: "",
                        refresh_duration: 1000,
                        width: 100,
                        height: 100,
                        x_element_name: "x",
                        y_element_name: "y",
                        get_new_point: function() {},
                        draw_history: null,
                        color: ""
                    },
                    $container = $(this);
                var settings = $.extend({}, defaults, options);
                var canvas = $("<canvas />").attr({ width: settings.width, height: settings.height })
                    .appendTo($container);
                context = canvas[0].getContext("2d");

                if (settings.draw_history) {
                    var promise = settings.draw_history();
                    promise.done(function (pointArray) {
                        if (pointArray.length === 0)
                            return;

                        points = [];
                        for (var i = 1; i < pointArray.length; i++) {
                            var point = pointArray[i];
                            point.x = point[settings.x_element_name];
                            point.y = point[settings.y_element_name];
                            points.push(point);
                        }

                        draw();
                    });
                } else {
                    getPoint(settings.get_new_point, settings.x_element_name, settings.y_element_name);
                }
                setCallTimeout(settings);
            },
            print: function() {},
            refresh: function() {}
        };

    function setCallTimeout(settings) {
        setTimeout(function () { (getPoint(settings.get_new_point, settings.x_element_name, settings.y_element_name)), setCallTimeout(settings); }, settings.refresh_duration);
    }

    function getPoint(action, xElementName, yElementName) {
        var promise = action();
        promise.done(function(pointArray) {
            if (pointArray.length === 0)
                return;

            var point = pointArray[0];
            point.x = point[xElementName];
            point.y = point[yElementName];
            points.push(point);
            draw();
        });
    };

    function draw() {
        var width = context.canvas.width;
        if (points.length === 0)
            return;

        var step = width * points.length / 100;
        var yVals = points.map(function (el) { return el.y; });
        var min = Math.min.apply(null, yVals);
        var max = Math.max.apply(null, yVals);

        for (var i = points.length - 1; i > 0; i--) {
            context.beginPath();
            context.moveTo(i * step, points[i].y);
            context.lineTo(i * step, points[i].y);
            context.lineTo((i - 1) * step, points[i - 1].y);
            context.fillText(points[i].x, i * step, 0);
            context.closePath();
            context.stroke();
            context.fill();
        }
    }

    $.fn.graph = function(method) {
        if (methods[method]) {
            return methods[method].apply(this, Array.prototype.slice.call(arguments, 1));
        } else if (typeof method === 'object' || !method) {
            return methods.init.apply(this, arguments);
        } else {
            $.error('Method ' + method + ' does not exist');
        }
    };
})(jQuery);