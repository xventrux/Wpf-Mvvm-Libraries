namespace Wpf.Mvvm.ViewModels
{
    /// <summary>
    /// Диалоговое окно с формой
    /// </summary>
    /// <typeparam name="TForm"></typeparam>
    public class FormDialogViewModel<TForm> : DialogViewModel, IFormable<TForm>
        where TForm : new()
    {
        private TForm _form;

        public FormDialogViewModel()
        {
            Form = new TForm();
        }

        /// <summary>
        /// Форма
        /// </summary>
        public TForm Form
        {
            get => _form;
            set => SetProperty(ref _form, value);
        }

        /// <summary>
        /// Форма
        /// </summary>
        object IFormable.Form => Form;

        /// <summary>
        /// При закрытии окна
        /// </summary>
        /// <param name="form"></param>
        protected virtual TForm OnClosing(TForm form) => form;

        /// <summary>
        /// Функция закрытия окна
        /// </summary>
        /// <param name="closeType"></param>
        protected override void TryCloseDialog(DialogButton closeType)
        {
            Form = OnClosing(Form);
            CloseRequest(new DialogResult<TForm>(Form, closeType));
        }
    }
}
