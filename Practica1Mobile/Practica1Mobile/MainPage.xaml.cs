using Xamarin.Forms;

namespace Practica1Mobile
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();

            // Inicializar el ViewModel
            viewModel = new MainPageViewModel();

            // Establecer el BindingContext
            BindingContext = viewModel;

            // Conectar comandos de los botones con los métodos correspondientes del ViewModel
            viewModel.AddTaskCommand = new Command(() =>
            {
                viewModel.AddTask(viewModel.NewTaskTitle, viewModel.NewTaskDescription);
                viewModel.NewTaskTitle = ""; // Limpiar el campo de entrada después de agregar la tarea
                viewModel.NewTaskDescription = "";
            });

            viewModel.EditTaskCommand = new Command(() =>
            {
                if (viewModel.SelectedTask != null)
                {
                    viewModel.EditTask(viewModel.SelectedTask, viewModel.NewTaskTitle, viewModel.NewTaskDescription);
                    viewModel.NewTaskTitle = ""; // Limpiar el campo de entrada después de editar la tarea
                    viewModel.NewTaskDescription = "";
                }
            });

            viewModel.DeleteTaskCommand = new Command(() =>
            {
                if (viewModel.SelectedTask != null)
                {
                    viewModel.DeleteTask(viewModel.SelectedTask);
                }
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Cargar las tareas al aparecer la página (puedes cargarlas desde un repositorio o archivo, por ejemplo)
            viewModel.LoadTasks();
        }
    }
}
