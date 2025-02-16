﻿using System;
using System.Collections.Generic;

namespace LapShopPr.Models;

public partial class TbPurchaseInvoice
{
    public int InvoiceId { get; set; }

    public DateTime InvoiceDate { get; set; }

    public int SupplierId { get; set; }

    public string? Notes { get; set; }

    public virtual TbSupplier Supplier { get; set; } = null!;

    public virtual ICollection<TbPurchaseInvoiceItem> TbPurchaseInvoiceItems { get; set; } = new List<TbPurchaseInvoiceItem>();
}
