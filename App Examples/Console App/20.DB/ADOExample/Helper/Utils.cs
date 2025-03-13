using System.Globalization;
using System.Threading.Tasks;
using Docker.DotNet;
using Docker.DotNet.Models;

namespace BoscComa.Helper
{
    public static class Utils
    {
        public static string CreateUUID() 
        {
            Guid myuuid = Guid.NewGuid();
            return myuuid.ToString();
        }

        public static DateTime ConvertToDate(string date,string culture)
        {
            CultureInfo cultureInfo = new CultureInfo(culture);
            return DateTime.Parse(date, cultureInfo);

        }

        public static async Task<bool> StopDocker(string containerName)
        {
            string containerId = containerName; 

            using (DockerClient client = new DockerClientConfiguration(new Uri("unix:///var/run/docker.sock")).CreateClient())
            {
                try
                {
                    await client.Containers.StopContainerAsync(containerId, new ContainerStopParameters());
                    Console.WriteLine($"Contenidor {containerId} aturat correctament.");
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error en aturar el contenidor: {ex.Message}");
                    return false;
                }
            }
        }
        public static async Task<bool> StartDocker(string containerName)
        {
            using (DockerClient client = new DockerClientConfiguration(new Uri("unix:///var/run/docker.sock")).CreateClient())
            {
                try
                {
                    // Obtenir l'ID del contenidor basat en el nom
                    var containers = await client.Containers.ListContainersAsync(new ContainersListParameters() { All = true });
                    var container = containers.FirstOrDefault(c => c.Names.Any(n => n.Contains(containerName)));

                    if (container == null)
                    {
                        Console.WriteLine($"No s'ha trobat cap contenidor amb el nom {containerName}.");
                        return false;
                    }

                    // Arrencar el contenidor
                    bool result = await client.Containers.StartContainerAsync(container.ID, new ContainerStartParameters());

                    if (result)
                    {
                        Console.WriteLine($"Contenidor {containerName} (ID: {container.ID}) arrencat correctament.");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine($"No s'ha pogut arrencar el contenidor {containerName}.");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error en arrencar el contenidor: {ex.Message}");
                    return false;
                }
            }
        }
    }
}