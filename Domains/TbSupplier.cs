﻿using System;
using System.Collections.Generic;

namespace LapShopPr.Models;

public partial class TbSupplier
{
    public int SupplierId { get; set; }

    public string SupplierName { get; set; } = null!;

    public virtual ICollection<TbPurchaseInvoice> TbPurchaseInvoices { get; set; } = new List<TbPurchaseInvoice>();
}
