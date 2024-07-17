using Wpf.Mvvm;

namespace Wpf.Navigation.Extensions
{
    public static class INavigationServiceExtensions
    {
        public static DialogResult ShowDialog<TViewModel>(this INavigationService navigationService)
            where TViewModel : DialogViewModel
        {
            return navigationService.ShowDialog(typeof(TViewModel));
        }

        public static DialogResult ShowDialog<TViewModel>(this INavigationService navigationService, object parameters)
            where TViewModel : DialogViewModel
        {
            return navigationService.ShowDialog(typeof(TViewModel), parameters);
        }

        public static DialogResult<TForm> ShowDialog<TViewModel, TForm>(this INavigationService navigationService)
            where TViewModel : DialogViewModel
        {
            return navigationService.ShowDialog(typeof(TViewModel)) as DialogResult<TForm>;
        }

        public static DialogResult<TForm> ShowDialog<TViewModel, TForm>(this INavigationService navigationService, object parameters)
            where TViewModel : DialogViewModel
        {
            return navigationService.ShowDialog(typeof(TViewModel), parameters) as DialogResult<TForm>;
        }

        public static DialogResult ShowMessageBox(this INavigationService navigationService, string message, MessageBoxType type, DialogButton buttons)
        {
            return navigationService.ShowMessageBox("Сообщение", message, type, buttons);
        }
    }
}
