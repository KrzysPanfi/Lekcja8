using System.Runtime.InteropServices;
using System.Text.Json;
using Lekcja8.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Lekcja8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private List<Animal> database = new List<Animal>();
        private List<Appointment> appointments = new List<Appointment>();
        public AnimalsController()
        {
            Animal a1 = new Animal { Id = 1, Name = "Rex", Category = "Pies", Color = "Brown", Weight = 12 };
            database.Add(a1);

            Animal a2 = new Animal { Id = 2, Name = "Max", Category = "Kot", Color = "Brown", Weight = 5 };
            database.Add(a2);

            Appointment p1 = new Appointment { Id = 1, AnimalId = 1, Date = DateTime.Now, Description = "test1", Price = 100 };
            appointments.Add(p1);

            Appointment p2 = new Appointment { Id = 2, AnimalId = 1, Date = DateTime.Now, Description = "test2", Price = 200 };
            appointments.Add(p2);


        }

        //GET /animals
        [HttpGet("animals")]
        public IActionResult GetAnimals()
        {
            return Ok(database);
        }

        //GET /animals/1
        [HttpGet("animal")]
        public IActionResult GetAnimal(int id)
        {
            foreach (var animal in database)
            {
                if (animal.Id == id)
                {
                    return Ok(JsonSerializer.Serialize(animal));
                }
            }
            return Ok("[]");
        }
        //POST /animals/1
        [HttpPost("addanimal")]
        public IActionResult AddAnimal(int id, String name, String category, String color, int weight)
        {
            Animal a_new = new Animal { Id = id, Name = name, Category = category, Color = color, Weight = weight };
            database.Add(a_new);
            return Ok(database);
        }
        //PUT /animals/1
        [HttpPut("editanimal")]
        public IActionResult EditAnimal(int id, String name, String category, String color, int weight)
        {
            foreach (var animal in database)
            {
                if (animal.Id == id)
                {
                    animal.Name = name;
                    animal.Category = category;
                    animal.Color = color;
                    animal.Weight = weight;
                }
            }
            return Ok(database);
        }
        //DELETE /animals/1
        [HttpDelete("deleteanimal")]
        public IActionResult DeleteAnimal(int id)
        {
            Animal ani = new Animal { };
            foreach (var animal in database)
            {
                if (animal.Id == id)
                {
                    ani = animal;
                }
            }
            database.Remove(ani);

            return Ok(database);
        }
        //GET /appointments/1
        [HttpGet("appointments")]
        public IActionResult GetAppointments(int animalid)
        {
            List<Appointment> result = new List<Appointment> { };
            foreach (var appointment in appointments)
            {
                if (appointment.AnimalId == animalid)
                {
                    result.Add(appointment);
                }
            }
            return Ok(result);
        }
        //POST /appointments/1
        [HttpPost("addappointment")]
        public IActionResult AddAppointment(int id, DateTime date, int animalid, string description, int price)
        {
            Appointment p_new = new Appointment();
            p_new.Id = id;
            p_new.Date = date;
            p_new.AnimalId = animalid;
            p_new.Description = description;
            p_new.Price = price;
            appointments.Add(p_new);

            return Ok(appointments);
        }

    }

}
