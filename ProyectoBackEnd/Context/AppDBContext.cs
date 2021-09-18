using Microsoft.EntityFrameworkCore;
using ProyectoBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBackEnd.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) //Opciones
        {

        }
        public DbSet<Estudiante> Estudiantes { get; set; }//Representacion de la tabla, Tiene qe coincidir con el nombre de la tabla
        public DbSet<Calificaciones> Calificaciones { get; set; }//Representacion de la tabla, Tiene qe coincidir con el nombre de la tabla

    }
}
