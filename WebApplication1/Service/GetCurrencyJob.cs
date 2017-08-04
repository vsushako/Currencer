using System;
using System.ComponentModel;
using System.Threading;

namespace WebApplication1.Service
{
    public class GetCurrencyJob
    {
        private readonly BackgroundWorker _worker = new BackgroundWorker();
        private readonly int _requestInterval; // интервал в миллисекундах
        private int _delay;
        private readonly Action _action;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="requestInterval">Интервал повторения запроса в минутах.</param>
        /// <param name="action">Обработчик</param>
        public GetCurrencyJob(int requestInterval, Action action)
        {
            _worker.DoWork += DoWork;
            _worker.RunWorkerCompleted += WorkerCompleted;
            _requestInterval = requestInterval * 60 * 1000;
            _action = action;
        }
        
        public void Start()
        {
            _worker.RunWorkerAsync();
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            if (_delay > 0)
            {
                Thread.Sleep(_delay);
                _delay = 0;
            }
            do
            {
                // Запускаем метод, который выполняет запрос
                _action();
                Thread.Sleep(_requestInterval);
            } while (true);
        }

        private void WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Thread.Sleep(10 * 1000);
            Start();
        }
    }
}