using Microsoft.Extensions.DependencyInjection;

namespace Wpf.Mvvm
{
    public interface IStartup
    {
        public void ConfigureServices(IServiceCollection services);
        public Type GetStartWindowViewModelType();
    }
}
