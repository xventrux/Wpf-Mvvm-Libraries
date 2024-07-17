using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Wpf.Mvvm
{
    /// <summary>
    /// Наблюдаемый объект
    /// </summary>
    public class ObservableObject : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged impl
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        /// <summary>
        /// Присваивает значение полю и уведомляет подписчиков
        /// </summary>
        /// <typeparam name="T">Тип поля</typeparam>
        /// <param name="backingStore">Переменная</param>
        /// <param name="value">Новое значение для поля</param>
        /// <param name="propertyName">Имя свойства</param>
        /// <param name="onChanged">Действие при успешном присваивании</param>
        /// <returns></returns>
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
