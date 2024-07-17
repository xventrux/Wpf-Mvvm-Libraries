namespace Wpf.Mvvm
{
    /// <summary>
    /// Результат диалогового окна
    /// </summary>
    public class DialogResult
    {
        public DialogResult(DialogButton result)
        {
            Result = result;
        }

        /// <summary>
        /// Тип завершения диалогового окна
        /// </summary>
        public DialogButton Result { get; set; }
    }

    /// <summary>
    /// Результат работы диалогового окна с формой
    /// </summary>
    /// <typeparam name="TForm">Тип формы диалогового окна</typeparam>
    public class DialogResult<TForm> : DialogResult, IFormable<TForm>
    {
        public DialogResult(TForm form, DialogButton result) : base(result)
        {
            Form = form;
        }

        /// <inheritdoc/>
        public TForm Form { get; }

        /// <inheritdoc/>
        object IFormable.Form => Form;
    }
}
