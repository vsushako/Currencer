
(function($) {

    var context,
        points = [],
        settings,
        methods = {
            init: function(options) {
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
                settings = $.extend({}, defaults, options);
                var canvas = $("<canvas />").attr({ width: settings.width, height: settings.height })
                    .appendTo($container)[0];
                context = canvas.getContext("2d");

                canvas.addEventListener("mousemove", function (e) {
                    var radius = 5;
                    var position = getMousePos(canvas, e);
                    var point = points.filter(function (p) {
                        var xPosition = Math.round(position.x);
                        var yPosition = Math.round(position.y);
 
                        return (Math.round(p.position.x) >= xPosition - radius &&  (Math.round(p.position.x) <= xPosition + radius)
                            && p.position.y >= yPosition - radius && p.position.y <= yPosition + radius);
                    });

                    // Если наверли на точку показываем
                    if (point.length > 0)
                        drawValue(context, point[0], 5);
                    else

                        draw();
                });

                getAllPoints();
                getPoint(settings.get_new_point, settings.x_element_name, settings.y_element_name);
                setCallTimeout();
            },
            refresh: function () {
                getAllPoints();
                getPoint(settings.get_new_point, settings.x_element_name, settings.y_element_name);
                draw();
            }
        };

    function drawValue(canvas, point, radius) {
        context.beginPath();
        context.arc(point.position.x, point.position.y, radius, 0, 2 * Math.PI);
        context.fill();
        context.fillText(Math.round(point.y * 100) / 100, point.position.x + radius * radius, point.position.y - radius);
        context.fillText(point.x, point.position.x, context.canvas.height);

    }

    function getMousePos(canvas, evt) {
        var rect = canvas.getBoundingClientRect();
        return {
            x: evt.clientX - rect.left,
            y: evt.clientY - rect.top
        };
    }

    function getAllPoints() {
        if (settings.draw_history) {
            var promise = settings.draw_history();
            promise.done(function (pointArray) {
                points = [];
                if (pointArray.length === 0)
                    return;

                for (var i = 1; i < pointArray.length; i++) {
                    var point = pointArray[i];
                    if (point.hasOwnProperty(settings.x_element_name) && point.hasOwnProperty(settings.y_element_name))
                        points.push({ x: point[settings.x_element_name], y: point[settings.y_element_name] });
                }

                draw();
            });
        }
    }

    function setCallTimeout() {
        setTimeout(function () { (getPoint(settings.get_new_point, settings.x_element_name, settings.y_element_name)), setCallTimeout(settings); }, settings.refresh_duration);
    }

    function getPoint(action, xElementName, yElementName) {
        var promise = action();
        promise.done(function(pointArray) {
            if (pointArray.length === 0)
                return;

            var point = pointArray[0];
            if (point.hasOwnProperty(settings.x_element_name) && point.hasOwnProperty(settings.y_element_name))
                points.push({ x: point[settings.x_element_name], y: point[settings.y_element_name] });
            draw();
        });
    };

    function clear() {
        context.clearRect(0, 0, context.canvas.width, context.canvas.height);
    }

    function getValue(avg, min, val){
        return ((val - min) / avg) * 100 | 0;
    }


    function draw() {
        clear();
        var width = context.canvas.width;
        if (points.length === 0)
            return;

        var step = width / points.length;
        var yVals = points.map(function (el) { return el.y; });
        var min = Math.min.apply(null, yVals);
        var max = Math.max.apply(null, yVals);
        var avg = max - min;
        points[0].position = { x: points.length * step, y: 100 - getValue(avg, min, points[0].y) };

        for (var i = 0; i < points.length - 1; i++) {
            var value = 100 - getValue(avg, min, points[i].y);
            var nextVal = 100 - getValue(avg, min, points[i + 1].y);
            points[i + 1].position = { x : (points.length - i - 1) * step, y: nextVal};

            context.beginPath();
            context.lineTo(points[i].position.x, points[i].position.y);
            context.lineTo(points[i + 1].position.x, points[i + 1].position.y);
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