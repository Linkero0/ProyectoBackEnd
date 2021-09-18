using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBackEnd.Models
{
    public class Estudiante
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string apellido { get; set; }
        [Required]
        public string fecNacimiento { get; set; }

    }

    public class Calificaciones
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int idEstudiante { get; set; }
        [Required]
        public string materia { get; set; }
        [Required]
        public string calificacion { get; set; }
        [Required]
        public string fechaAlta { get; set; }

    }
}

