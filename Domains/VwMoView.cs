namespace LapShopPr.Models
{
    public class VwMoView
    {
        public int ItemId { get; set; }

        public string ItemName { get; set; } = null!;

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public decimal SalesPrice { get; set; }

        public decimal PurchasePrice { get; set; }

      

        public string? ImageName { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; } = null!;

        public int CurrentState { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string? Description { get; set; }

        public string? Gpu { get; set; }

        public string? HardDisk { get; set; }

        public int? ItemTypeId { get; set; }

        public string? Processor { get; set; }

        public int? RamSize { get; set; }

        public string? ScreenReslution { get; set; }

        public string? ScreenSize { get; set; }

        public string? Weight { get; set; }

        public int? OsId { get; set; }
    }
}
