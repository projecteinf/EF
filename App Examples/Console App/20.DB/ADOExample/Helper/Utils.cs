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
    }
}