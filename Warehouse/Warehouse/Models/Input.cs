namespace Warehouse.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Input")]
    public partial class Input
    {
        public int id { get; set; }

        public int? idSupply { get; set; }

        public int? idProduct { get; set; }

        public int? quantity { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? date { get; set; }

        public virtual Product Product { get; set; }

        public virtual Supply Supply { get; set; }
    }
}
