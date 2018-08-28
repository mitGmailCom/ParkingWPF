using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingWPF
{
    public class ClientCarRelation
    {
        public ClientCarRelation()
        { }
        public int Id { get; set; }
        [Required]
        public int ClientId { get; set; }
        [Required]
        public int CarId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Car Car { get; set; }
    }
}
