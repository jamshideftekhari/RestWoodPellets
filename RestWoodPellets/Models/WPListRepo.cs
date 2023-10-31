namespace RestWoodPellets.Models
{
    public class WPListRepo
    {
        private int nextId = 1;
        private readonly List<WoodPallet> woodPallets = new();

        public WPListRepo()
        {
            woodPallets.Add(new WoodPallet() { Id = nextId++, Brand = "BioWood", Price = 4995, Quality = 4});
            woodPallets.Add(new WoodPallet() { Id = nextId++, Brand = "BilligPille", Price = 4125, Quality = 1});
            woodPallets.Add(new WoodPallet() { Id = nextId++, Brand = "GoldenWoodPellet", Price = 5995, Quality = 5 });

        }

        public IEnumerable<WoodPallet> Get()
        {
            IEnumerable<WoodPallet> result = new List<WoodPallet>(woodPallets); 
            return result;
        }

        public WoodPallet? GetById(int id)
        {
            return woodPallets.Find(wp => wp.Id == id);
        }

        public WoodPallet Add(WoodPallet wp)
        {
            wp.Id = nextId++;
            woodPallets.Add((WoodPallet)wp);
            return wp;
        }

        public WoodPallet? Remove(int id) 
        {
            WoodPallet? wp = GetById(id);
            if (wp != null)
            {
                woodPallets.Remove(wp);
                return wp;
            }
            return null;
        }
    }
}
