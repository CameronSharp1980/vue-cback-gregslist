namespace vue_cback_gregslist.Models
{
    public class Property
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public string Title { get; set; }
        public string Zoning { get; set; }
        public int SquareFootage { get; set; }
        public int YearBuilt { get; set; }
        public string Color { get; set; }
        public string ListingDescription { get; set; }
        public string ListingLocation { get; set; }
        public string ImageURL { get; set; }
        public double Price { get; set; }
    }
}