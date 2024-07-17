using Wpf.Mvvm;

namespace Wpf.Navigation
{
    public interface INavigationService
    {
        /// <summary>
        /// Открывает диалоговое окно
        /// </summary>
        /// <param name="viewModelType">Тип ViewModel диалогового окна</param>
        /// <returns></returns>
        DialogResult ShowDialog(Type viewModelType);

        /// <summary>
        /// Открывает диалоговое окно с входными параметрами
        /// </summary>
        /// <returns></returns>
        DialogResult ShowDialog(Type viewModelType, object parameters);

        /// <summary>
        /// Открывает окно
        /// </summary>
        /// <typeparam name="TViewModel">Тип ViewModel окна</typeparam>
        void ShowWindow(Type viewModelType);

        /// <summary>
        /// Открывает MessageBox
        /// </summary>
        /// <param name="message">Сообщение</param>
        DialogResult ShowMessageBox(string title, string message, MessageBoxType type, DialogButton buttons);
    }
}
