namespace Warehouse.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sold")]
    public partial class Sold
    {
        public int id { get; set; }

        public int? idDetail_Product { get; set; }

        public int? quantity { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? date { get; set; }

        public virtual Detail_Product Detail_Product { get; set; }
    }
}
