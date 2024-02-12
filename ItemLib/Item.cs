using SpecialOfferLib;

namespace ItemLib
{
    public class Item
    {
        public char Name { get; set; }
        public int Price { get; set; }
        public SpecialOffer? SpecialOffer { get; set; }
    }

}
