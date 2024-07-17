namespace Wpf.Mvvm
{
    /// <summary>
    /// Параметры для MessageBox
    /// </summary>
    public class MessageBoxParameters
    {
        /// <summary>
        /// Заголовок окна сообщения
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Сообщение
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Кнопки для окна сообщения
        /// </summary>
        public DialogButton DialogButtons { get; set; }

        /// <summary>
        /// Тип окна сообщения
        /// </summary>
        public MessageBoxType Type { get; set; }
    }
}
