//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GoodtoGo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductSale
    {
        public int Id { get; set; }
        public Nullable<int> saleId { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> Price { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Sale Sale { get; set; }
    }
}
