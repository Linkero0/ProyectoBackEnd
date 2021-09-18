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
    public class CalificacionesController : Controller
    {
        private readonly AppDBContext context;

        public CalificacionesController(AppDBContext context)
        {

            this.context = context;
        }
    // GET: CalificacionesController
    [HttpGet]
        public ActionResult Get([FromQuery] Calificaciones calificaciones)
        {
            try
            {

                return Ok(context.Calificaciones.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }

        [HttpGet("{id}", Name = "GetScore")]
        public ActionResult Get([FromQuery] Calificaciones calificaciones,int id)
        {
            try
            {
                var califiaciones = context.Calificaciones.FirstOrDefault(e => e.id == id);

                return Ok(califiaciones);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }

        [HttpPost]
        public ActionResult post([FromBody] Calificaciones calificacion)
        {
            try
            {
                context.Calificaciones.Add(calificacion);
                context.SaveChanges();
                return CreatedAtRoute("GetScore", new { id = calificacion.id }, calificacion);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Calificaciones calificaciones)
        {
            try
            {
                if (calificaciones.id == id)
                {

                    context.Entry(calificaciones).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetScore", new { id = calificaciones.id }, calificaciones);

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
        public ActionResult Delete(int id, [FromBody] Calificaciones calificacio)
        {
            try
            {
                var calificaciones = context.Calificaciones.FirstOrDefault(e => e.id == id);
                if (calificaciones != null)
                {
                    context.Calificaciones.Remove(calificaciones);
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

        [HttpGet("getByIdEstudent/{id}")]
        public ActionResult GetByStudent(int id, [FromBody] Calificaciones calificacion)
        {
            try
            {
                var calificaciones = context.Calificaciones.Where(e => e.idEstudiante == id);
                if (calificaciones != null)
                {

                    return Ok(calificaciones.ToList());
                }
                else
                {

                    return BadRequest("Estudiante no encontrado");
                }
             
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
