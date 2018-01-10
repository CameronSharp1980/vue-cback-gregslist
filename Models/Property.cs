namespace vue_cback_gregslist.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Zoning { get; set; }
        public int SquareFootage { get; set; }
        public string Color { get; set; }
        public string PropertyDescription { get; set; }
        public string ImageURL { get; set; }
        public double Price { get; set; }
        //add yearBuilt, creator id
    }
}