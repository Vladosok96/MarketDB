using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketDB
{

    public class SalesPoint
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ProvidedProduct> ProvidedProducts { get; set;}
        public virtual ICollection<Sale> Sales { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public virtual ICollection<ProvidedProduct> ProvidedProducts { get; set; }
    }

    public class ProvidedProduct
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int SalesPointId { get; set; }
        public virtual SalesPoint SalesPoint { get; set;}

        public int ProductQuantity { get; set; }
    }

    public class Buyer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Sale> SalesIds { get; set; }

    }

    public class Sale
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        
        public int SalesPointId { get; set; }
        public SalesPoint SalesPoint { get; set; }
        
        public int BuyerId { get; set; }
        public Buyer Buyer { get; set; }

        public virtual ICollection<SaleData> SalesData { get; set; }

        public float TotalAmount { get; set; }
    }

    public class SaleData
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int SaleId { get; set; }
        public virtual Sale Sale { get; set; }

        public int ProductQuantity { get; set; }
        public float ProductIdAmount { get; set; }
    }
}
