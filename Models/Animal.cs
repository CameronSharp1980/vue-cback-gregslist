namespace vue_cback_gregslist.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public string Title { get; set; }
        public string AnimalName { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public string Color { get; set; }
        public string ListingDescription { get; set; }
        public string ListingLocation { get; set; }
        public string MedicalConcerns { get; set; }
        public string ImageURL { get; set; }
        public double Price { get; set; }
    }
}