using System;

namespace LogAn
{
    public class Presenter
    {
        private readonly IView _view;

        public Presenter(IView view, ILogger logger)
        {
            _view = view;
            
            this._view.Loaded += OnLoaded;
            this._view.ErrorOccured += logger.LogError;
        }

        private void OnLoaded()
        {
            _view.Render("Hello World");
        }
    }

    public interface IView
    {
        event Action Loaded;
        event Action<string> ErrorOccured;
        void Render(string text);
    }
}