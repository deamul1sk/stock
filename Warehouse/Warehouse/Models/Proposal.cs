namespace Warehouse.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Proposal")]
    public partial class Proposal
    {
        public int id { get; set; }

        public int? idStock { get; set; }

        public int? quantity { get; set; }

        public static explicit operator List<object>(Proposal v)
        {
            throw new NotImplementedException();
        }

        public int? isDelete { get; set; }

        public virtual Stock Stock { get; set; }
    }
}
