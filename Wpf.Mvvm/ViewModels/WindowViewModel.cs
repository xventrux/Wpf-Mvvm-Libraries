namespace Wpf.Mvvm
{
    /// <summary>
    /// ViewModel окна
    /// </summary>
    public class WindowViewModel : ObservableObject
    {
        private string _title;

        /// <summary>
        /// Заголовок окна
        /// </summary>
        public string Title 
        { 
            get => _title; 
            set => SetProperty(ref _title, value); 
        }

        /// <summary>
        /// Вызывается при загрузке окна
        /// </summary>
        public virtual void OnLoaded() { }
    }
}
