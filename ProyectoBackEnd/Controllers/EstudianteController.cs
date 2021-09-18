using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoBackEnd.Context;
using ProyectoBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBackEnd.Controllers
{
    [Route("api/[controller]")]
    public class EstudianteController : Controller
    {

        private readonly AppDBContext context;

        public EstudianteController(AppDBContext context)
        {

            this.context = context;
        }
        // GET: EstudianteController

        [HttpGet]
        public ActionResult Get()
        {
            try
            {

                return Ok(context.Estudiantes.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }

        [HttpGet("{id}", Name = "GetEstudents")]
        public ActionResult Get(int id)
        {
            try
            {
                var estudiante = context.Estudiantes.FirstOrDefault(e => e.id == id);

                return Ok(estudiante);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }

        // [HttpPost]
        public ActionResult post([FromBody] Estudiante estudiante)
        {
            try
            {
                context.Estudiantes.Add(estudiante);
                context.SaveChanges();
                return CreatedAtRoute("GetEstudents", new { id = estudiante.id }, estudiante);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Estudiante estudiante)
        {
            try
            {
                if (estudiante.id == id)
                {

                    context.Entry(estudiante).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetEstudents", new { id = estudiante.id }, estudiante);

                }
                else
                {

                    return BadRequest();
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var estudiante = context.Estudiantes.FirstOrDefault(e => e.id == id);
                if (estudiante != null)
                {
                    context.Estudiantes.Remove(estudiante);
                    context.SaveChanges();

                    return Ok("Se ha eliminado el registro" + id);
                }
                else
                {

                    return BadRequest("Registro no encontrado");
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
