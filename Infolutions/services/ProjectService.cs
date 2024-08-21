using Infolutions.http;
using System.Text;
using System.Threading.Tasks;

namespace Infolutions.services
{
    public class ProjectService : ApiConect
    {
        private readonly string groupKey = "ejemplo";

        // Método para obtener la lista de proyectos (Read)
        public async Task<object> Index()
        {
            string path = $"/projects{groupKey}";
            string body = "";
            var rs = await SendTransaction(path, body, "GET");

            return rs.Data;
        }

        // Método para obtener un proyecto específico por ID (Read)
        public async Task<object> Show(int projectId)
        {
            string path = $"/projects/{projectId}/{groupKey}";
            string body = "";
            var rs = await SendTransaction(path, body, "GET");

            return rs.Data;
        }

        // Método para crear un nuevo proyecto (Create)
        public async Task<object> CreateProjectAsync(string projectData)
        {
            string path = $"/projects/{groupKey}";
            var rs = await SendTransaction(path, projectData, "POST");

            return rs;
        }

        // Método para actualizar un proyecto existente (Update)
        public async Task<string> UpdateProjectAsync(int projectId, string projectData)
        {
            string path = $"/projects/{projectId}";
            var rs = await SendTransaction(path, projectData, "PUT");

            return rs.Message;
        }

        // Método para eliminar un proyecto (Delete)
        public async Task<string> DeleteProjectAsync(int projectId)
        {
            string path = $"/projects/{projectId}";
            string body = "";  // No se requiere un cuerpo para el método DELETE
            var rs = await SendTransaction(path, body, "DELETE");

            return rs.Message;
        }
    }
}
