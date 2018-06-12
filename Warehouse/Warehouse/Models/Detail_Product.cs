namespace Warehouse.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Detail_Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Detail_Product()
        {
            Solds = new HashSet<Sold>();
        }

        public int id { get; set; }

        public int? idProduct { get; set; }

        public int? idBill { get; set; }

        public decimal? price { get; set; }

        public int? quantity { get; set; }

        public virtual Bill Bill { get; set; }

        public virtual Product Product { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sold> Solds { get; set; }
    }
}
