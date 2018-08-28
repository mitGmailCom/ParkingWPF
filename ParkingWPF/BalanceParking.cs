using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingWPF
{
    public class BalanceParking
    {
        public BalanceParking() { }

        public int Id { get; set; }
        [Required]
        public int ClientId { get; set; }
        [Required]
        public int CarId { get; set; }
        [Required]
        [Column("DateAdded", TypeName = "date")]
        public DateTime DataAdded { get; set; }
        [Required]
        public int Place { get; set; }

        public virtual Client Client { get; set; }
        public virtual Car Car { get; set; }
    }
}
