namespace LapShopPr.Models
{
    public class VwHomePage
    {

        public VwHomePage()
        {
            LstAllItem = new List<VwItem>();
            LstRecommendedItem = new List<VwItem>();
            LstNewItem = new List<VwItem>();
            LstFreeDelivaryItem = new List<VwItem>();
            LstCategories = new List<TbCategory>();

        }

        public List<VwItem> LstAllItem { get; set; }
        public List<VwItem> LstRecommendedItem { get; set; }
        public List<VwItem> LstNewItem { get; set; }
        public List<VwItem> LstFreeDelivaryItem { get; set; }
        public List<TbCategory> LstCategories { get; set; }

        public List<TbSlider> LstSlider { get; set; }

        public TbSettings settings { get; set; }




    }
}
