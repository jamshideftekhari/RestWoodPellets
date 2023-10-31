namespace RestWoodPellets.Models
{
    public class WPConstrains
    {
        public int Id { get; set; }
        public string? Brand { get; set; }
        public double Price { get; set; }
        public int Quality { get; set; }


        public override string ToString()
        {
            return $"{Id} {Brand} {Price} {Quality}";
        }

        public void ValidateBrand()
        {
            if (Brand == null) throw  new ArgumentNullException("Brand is null");
            if (Brand.Length < 3) throw new ArgumentException("Brand name must be at least 3 characters" + Brand);
        }

        public void Validateprice()
        {
            if (Price < 0) throw new ArgumentOutOfRangeException("Price should be possitive" + Price); 
        }
    }

    
}
