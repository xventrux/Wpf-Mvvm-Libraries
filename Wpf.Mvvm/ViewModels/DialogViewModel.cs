using System.Windows.Input;

namespace Wpf.Mvvm
{
    /// <summary>
    /// Базовая ViewModel диалогового окна
    /// </summary>
    public class DialogViewModel : WindowViewModel
    {

        public DialogViewModel()
        {
            AcceptCommand = new RelayCommand((obj) => {
                bool isSusccess = AcceptCommandHandle();
                if (isSusccess)
                    TryCloseDialog(DialogButton.Ok);
            });

            CancelCommand = new RelayCommand((obj) => {
                CancelCommandHandle();
                TryCloseDialog(DialogButton.Cancel);
            });
        }

        /// <summary>
        /// Запрос на закрытие
        /// </summary>
        public event Action<DialogResult> RequestClose;

        /// <summary>
        /// Команда "Ок"
        /// </summary>
        public ICommand AcceptCommand { get; }

        /// <summary>
        /// Команда "Отмена"
        /// </summary>
        public ICommand CancelCommand { get; }

        /// <summary>
        /// Происходит при закрытии окна
        /// </summary>
        public virtual void OnClosed() { }

        /// <summary>
        /// Метод обработки команды <see cref="AcceptCommand"/>
        /// </summary>
        protected virtual bool AcceptCommandHandle() => true;

        /// <summary>
        /// Метод обработки команды <see cref="CancelCommand"/>
        /// </summary>
        protected virtual void CancelCommandHandle() { }

        protected virtual void TryCloseDialog(DialogButton closeType)
        {
            CloseRequest(new DialogResult(closeType));
        }

        /// <summary>
        /// Запрос на закрытие диалогового окна
        /// </summary>
        /// <param name="dialogResult">Результат работы диалогового окна</param>
        protected void CloseRequest(DialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }
    }
}
