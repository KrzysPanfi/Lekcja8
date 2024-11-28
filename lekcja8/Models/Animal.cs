namespace Lekcja8.Models
{
    // GET /animals
    // GET /animals/id
    // POST /animals
    // PUT  /animals/id
    // DELETE animals/id
    public class Animal
    {
        //prop
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }
    }
}
