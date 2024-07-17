using System.Windows;
using Wpf.Mvvm;

namespace Wpf.Navigation
{
    public class NavigationService : INavigationService
    {
        private readonly Func<Type, ObservableObject> _viewModelFactory;
        private readonly Func<Type, FrameworkElement> _viewFactory;

        public NavigationService(Func<Type, ObservableObject> viewModelFactory,
            Func<Type, FrameworkElement> viewFactory)
        {
            _viewModelFactory = viewModelFactory ?? throw new ArgumentNullException(nameof(viewModelFactory));
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
        }

        public DialogResult ShowDialog(Type viewModelType)
        {
            return ShowDialog(viewModelType, null);
        }

        public DialogResult ShowDialog(Type viewModelType, object parameters)
        {
            DialogViewModel vm = MakeViewModel<DialogViewModel>(viewModelType);
            Window window = MakeWindow(vm, parameters);

            DialogResult result = null;

            vm.RequestClose += (res) =>
            {
                result = res;
                window.Close();
            };


            window.Closed += (obj, e) => vm.OnClosed();
            window.ShowDialog();

            return result;
        }

        public DialogResult ShowMessageBox(string title, string message, MessageBoxType type, DialogButton buttons)
        {
            return ShowDialog(typeof(MessageBoxViewModel), new MessageBoxParameters()
            {
                Title = title,
                Message = message,
                DialogButtons = buttons,
                Type = type
            });
        }

        public void ShowWindow(Type viewModelType)
        {
            WindowViewModel viewModel = MakeViewModel<WindowViewModel>(viewModelType);
            Window window = MakeWindow(viewModel);
            window.Show();
        }

        private Window MakeWindow<T>(T viewModel, object parameters = null)
            where T : WindowViewModel
        {
            Window wind = _viewFactory.Invoke(viewModel.GetType()) as Window ?? throw new NullReferenceException(nameof(viewModel));

            wind.DataContext = viewModel;
            wind.Loaded += (obj, e) =>
            {
                viewModel.OnLoaded();

                if (parameters != null && viewModel is IParameterable parameterable)
                    parameterable.HandleParameters(parameters);
            };

            return wind;
        }

        private T MakeViewModel<T>(Type viewModelType)
            where T : ObservableObject
        {
            return _viewModelFactory.Invoke(viewModelType) as T ?? throw new ArgumentNullException(nameof(viewModelType));
        }

        
    }
}
