namespace Lekcja8.Models
{
    // GET /animals
    // GET /animals/id
    // POST /animals
    // PUT  /animals/id
    // DELETE animals/id
    public class Appointment
    {
        //prop
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int AnimalId { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
}