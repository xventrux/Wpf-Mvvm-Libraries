namespace Wpf.Mvvm
{
    /// <summary>
    /// ViewModel диалогового окна
    /// </summary>
    public class MessageBoxViewModel : DialogViewModel, IParameterable<MessageBoxParameters>
    {
        private string _message;
        private DialogButton _buttons;
        private MessageBoxType _type;

        /// <summary>
        /// Сообщение диалогового окна
        /// </summary>
        public string Message { get => _message; set => SetProperty(ref _message, value); }

        /// <summary>
        /// Кнопки диалогового окна
        /// </summary>
        public DialogButton Buttons { get => _buttons; set => SetProperty(ref _buttons, value); }

        /// <summary>
        /// Тип диалогового окна
        /// </summary>
        public MessageBoxType Type { get => _type; set => SetProperty(ref _type, value); }

        public void HandleParameters(MessageBoxParameters parametes)
        {
            Title = String.IsNullOrEmpty(parametes.Title) ? "Сообщение" : parametes.Title;
            Message = parametes.Message;
            Buttons = parametes.DialogButtons;
            Type = parametes.Type;
        }

        public void HandleParameters(object parametes)
        {
            HandleParameters(parametes as MessageBoxParameters);
        }
    }
}
