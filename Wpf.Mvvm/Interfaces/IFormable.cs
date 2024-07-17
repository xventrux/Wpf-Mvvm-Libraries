namespace Wpf.Mvvm
{
    public interface IFormable
    {
        /// <summary>
        /// Форма
        /// </summary>
        object Form { get; }
    }
    public interface IFormable<TForm> : IFormable
    {
        /// <summary>
        /// Форма
        /// </summary>
        TForm Form { get; }
    }
}
