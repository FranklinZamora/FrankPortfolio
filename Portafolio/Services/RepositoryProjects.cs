using Portafolio.Models;

namespace Portafolio.Services
{

    public interface IRepositoryProjects
    {
        List<ProjectDTO> ObtainProyect();
    }

    public class RepositoryProjects : IRepositoryProjects
    {
        public List<ProjectDTO> ObtainProyect()
        {
            return new List<ProjectDTO>() {
            new ProjectDTO()
            {  
                Title = "AquaNode",
                Description = "Feeder complementary module for reading parameters in the feeding area",
                link = "https://www.instagram.com/reel/C1-k09UOoX7/?utm_source=ig_web_copy_link&igsh=MzRlODBiNWFlZA==",
                ImageURL = "/Images/AquaNode.png"
            },
            new ProjectDTO()
            {
                Title = "WaterWise",
                Description = "Sensors for reading parameters in ponds with alerts, history and set points developed in C++ and Altium designer",
                link = "https://www.nasystems.mx/landpage",
                ImageURL = "/Images/WaterWise.png"
            },
            new ProjectDTO()
            {
                Title = "AtmoSense",
                Description = "Weather station using LoRa module for communication, developed in C++, Python and JavaScript",
                link = "https://github.com/FranklinZamora/AtmoSenseTEC",
                ImageURL = "/Images/AtmoSense.png"
            },
            new ProjectDTO()
            {
                Title = "Serial NAS",
                Description = "Serial monitor for the validation of cards with UART protocol developed in C# / NET",
                link = "https://github.com/FranklinZamora/SerialMonitor.git",
                ImageURL = "/Images/SerialNAS.png"
            },

            };
        }
    }
}
