﻿using System;
using System.Collections.Generic;

namespace LapShopPr.Models
{

    public partial class TbSalesInvoiceItem
    {
        public int InvoiceItemId { get; set; }

        public int ItemId { get; set; }

        public int InvoiceId { get; set; }

        public double Qty { get; set; }

        public decimal InvoicePrice { get; set; }

        public string? Notes { get; set; }

        public virtual TbSalesInvoice Invoice { get; set; } = null!;

        public virtual TbItem Item { get; set; } = null!;
    }
}