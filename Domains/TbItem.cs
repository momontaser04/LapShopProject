using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LapShopPr.Models;

public partial class TbItem
{
    [ValidateNever]
    [Required(ErrorMessage ="Please Enter Your Id")]
    public int ItemId { get; set; }

    [Required(ErrorMessage = "Please Enter Your ItemName")]
    public string ItemName { get; set; } = null!;
    

    [Range(1000, 100000, ErrorMessage = "Please enter a valid price between 1000 and 100000")]
    public decimal SalesPrice { get; set; }


    [Range(1000, 100000, ErrorMessage = "Please enter a valid price between 1000 and 100000")]

    public decimal PurchasePrice { get; set; }

  
    [Required(ErrorMessage = "Please enter category")]
    public int CategoryId { get; set; }

    public string? ImageName { get; set; }


    public DateTime CreatedDate { get; set; }

    [ValidateNever]
    public string CreatedBy { get; set; } = null!;

    public int CurrentState { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? Description { get; set; }

    [Required(ErrorMessage = "Please Enter Your Gpu")]
    public string? Gpu { get; set; }
    [Required(ErrorMessage = "Please Enter Your HardDisk")]
    public string? HardDisk { get; set; }
    [Required(ErrorMessage = "Please Enter Your ItemTypeId")]
    public int? ItemTypeId { get; set; }
    [Required(ErrorMessage = "Please Enter Your Processor")]
    public string? Processor { get; set; }
    [Required(ErrorMessage = "Please Enter Your RamSize")]
    public int? RamSize { get; set; }
    [Required(ErrorMessage = "Please Enter Your ScreenReslution")]
    public string? ScreenReslution { get; set; }
    [Required(ErrorMessage = "Please Enter Your ScreenSize")]
    public string? ScreenSize { get; set; }
    [Required(ErrorMessage = "Please Enter Your Weight")]
    [ValidateNever]
    public string? Weight { get; set; }
    [Required(ErrorMessage = "Please Enter Your Operating System")]
    public int? OsId { get; set; }

    [ValidateNever]
    public virtual TbCategory Category { get; set; } = null!;
    [ValidateNever]
    public virtual TbItemType? ItemType { get; set; }
    [ValidateNever]
    public virtual TbO? Os { get; set; }

    public virtual ICollection<TbItemDiscount> TbItemDiscounts { get; set; } = new List<TbItemDiscount>();

    public virtual ICollection<TbItemImage> TbItemImages { get; set; } = new List<TbItemImage>();

    public virtual ICollection<TbPurchaseInvoiceItem> TbPurchaseInvoiceItems { get; set; } = new List<TbPurchaseInvoiceItem>();

    public virtual ICollection<TbSalesInvoiceItem> TbSalesInvoiceItems { get; set; } = new List<TbSalesInvoiceItem>();

    public virtual ICollection<TbCustomer> Customers { get; set; } = new List<TbCustomer>();
}
