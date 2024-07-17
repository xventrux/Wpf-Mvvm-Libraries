namespace Wpf.Mvvm
{
    /// <summary>
    /// Обрабатывающий входные параметры
    /// </summary>
    public interface IParameterable
    {
        /// <summary>
        /// Метод для обработки входных параметров
        /// </summary>
        void HandleParameters(object parametes);
    }

    /// <summary>
    /// Обрабатывающий входные параметры
    /// </summary>
    /// <typeparam name="TParam">Тип входных параметров</typeparam>
    public interface IParameterable<TParam> : IParameterable
    {
        /// <summary>
        /// Метод для обработки входных параметров
        /// </summary>
        /// <param name="parametes">Входные параметры</param>
        void HandleParameters(TParam parametes);
    }
}
