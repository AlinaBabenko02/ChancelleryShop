using System;
using System.Collections.Generic;

#nullable disable

namespace ChancelleryShop
{
    public partial class Shop
    {
        public Shop()
        {
            Receipts = new HashSet<Receipt>();
        }

        public int ShopId { get; set; }
        public string ShopAdress { get; set; }
        public string ShopCity { get; set; }

        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}
