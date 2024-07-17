using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using Wpf.Mvvm;

namespace Wpf.Navigation.Extensions
{
    public static class IServiceCollectionExtensions
    {
        private static Dictionary<Type, Type> s_viewModelView;

        /// <summary>
        /// Регистрирует сервис для навигации
        /// </summary>
        /// <returns></returns>
        public static IServiceCollection AddNavigationService(this IServiceCollection services)
        {
            s_viewModelView = new Dictionary<Type, Type>();

            services.AddSingleton<Func<Type, ObservableObject>>(serviceProvider => type =>
            {
                ObservableObject vm = (ObservableObject)serviceProvider.GetRequiredService(type);
                return vm;
            });
            services.AddSingleton<Func<Type, FrameworkElement>>(serviceProvider => (type) =>
            {
                Type viewType = s_viewModelView[type];
                return (FrameworkElement)serviceProvider.GetRequiredService(viewType);
            });

            services.AddSingleton(s_viewModelView);

            return services.AddSingleton<INavigationService, NavigationService>();
        }

        public static IServiceCollection AddMessageBoxView<TView>(this IServiceCollection services)
            where TView : Window
        {
            return services.AddWindow<TView, MessageBoxViewModel>();
        }

        /// <summary>
        /// Регистрирует View, и ViewModel для нее
        /// </summary>
        /// <typeparam name="TView">View</typeparam>
        /// <typeparam name="TViewModel">ViewModel</typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddWindow<TView, TViewModel>(this IServiceCollection services) where TViewModel : WindowViewModel
            where TView : Window
        {
            services.AddTransient(typeof(TView));
            services.AddTransient(typeof(TViewModel));

            s_viewModelView[typeof(TViewModel)] = typeof(TView);

            return services;
        }
    }
}
