﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LapShopPr.Models;

public class TbPages
{
    public int PageId {  get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string MetaKeyword { get; set; } = null!;
    public string MetaDescription { get; set; } = null!;
    public string ImageName { get; set; } = null!;
    public DateTime CreatedDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }




}
