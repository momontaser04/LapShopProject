﻿namespace LapShopPr.Models
{
    public class ShoppingCart
    {

        public ShoppingCart()
        {
            LstItems = new List<ShoppingCartItem>();

        }

        public List<ShoppingCartItem> LstItems { get; set; }
        public decimal Total { get; set; }
        public string Promocode {  get; set; }

    }
}
