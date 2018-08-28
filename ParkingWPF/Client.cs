using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingWPF
{
    public class Client
    {
        public Client() { }

        public int Id { get; set; }
        [Required, MaxLength(30)]
        public string LastName { get; set; }
        [Required, MaxLength(30)]
        public string FirstName { get; set; }
        [Required, MaxLength(30)]
        public string MidleName { get; set; }
        [Required]
        public int Phone { get; set; }
        [Required, MaxLength(65)]
        public string Adress { get; set; }

        public virtual ICollection<ClientCarRelation> ClientCarRelations { get; set; }
    }
}
