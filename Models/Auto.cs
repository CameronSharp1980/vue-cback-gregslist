namespace vue_cback_gregslist.Models
{
    public class Auto
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public string Title { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string AutoDescription { get; set; }
        public string Location { get; set; }
        public string ImageURL { get; set; }
        public double Price { get; set; }
        
    }
}