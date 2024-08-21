using Infolutions.services;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infolutions
{
    public partial class Form1 : Form
    {
        ProjectService projectService = new ProjectService();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Ejecutar la lógica en un hilo de fondo para evitar bloquear la UI
            Task.Run(async () =>
            {
                // Obtener todos los proyectos
                var proyectos = await projectService.Index();

                // Obtener un proyecto por su ID
                var proyecto = await projectService.Show(1);

                // Crear un nuevo proyecto
                var newProject = new
                {
                    name = "Nuevo Proyecto oooo",
                    description = "Descripción del nuevo proyecto",
                    status = "pendiente",
                    totalHours = 100,
                    created_at = "2024-10-01"
                };

                string projectDataJson = JsonSerializer.Serialize(newProject);


                object responseMessage = await projectService.CreateProjectAsync(projectDataJson);


            });
        }
    }
}
