namespace Warehouse.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Detail_Stock
    {
        public int id { get; set; }

        public int? idStock { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateBegin { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateEnd { get; set; }

        public int? nhap { get; set; }

        public int? da { get; set; }

        public int? con { get; set; }

        public virtual Stock Stock { get; set; }
    }
}
