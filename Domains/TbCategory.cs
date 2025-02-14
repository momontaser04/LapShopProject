using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LapShopPr.Models;

public partial class TbCategory
{
    [ValidateNever]
    public int CategoryId { get; set; }
    [Required(ErrorMessage ="Please Enter Category Name")]
    public string CategoryName { get; set; }

    public string ?CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CurrentState { get; set; }

    public string ?ImageName { get; set; } 

    public bool ShowInHomePage { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<TbItem> TbItems { get; set; } = new List<TbItem>();
}
