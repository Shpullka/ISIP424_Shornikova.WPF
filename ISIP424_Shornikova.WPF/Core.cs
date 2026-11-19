using ISIP424_Shornikova.WPF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP424_Shornikova.WPF
{
    internal class Core
    {
        public static ShopBD_Shpullka424Entities Context = new ShopBD_Shpullka424Entities();
        public static List<CartItem> Cart = new List<CartItem>();
    }

    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => Product.Price * Quantity;
    }
}
