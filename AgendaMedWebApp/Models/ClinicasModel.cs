using AgendaMed.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaMedWebApp.Models
{
    public class ClinicasModel
    {
        public List<ClinicaModel> Clinicas { get; set; } = new List<ClinicaModel>();
    }
}
