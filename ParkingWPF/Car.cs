using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingWPF
{
    public class Car
    {
        public Car() {
            ClientCarRelations = new List<ClientCarRelation>();
        }

        public int Id { get; set; }
        [Required, MaxLength (25)]
        public string Manufacture { get; set; }
        [Required, MaxLength(25)]
        public string Model { get; set; }
        [Required, MaxLength(25)]
        public string Color { get; set; }
        [Required]
        public string NumberCar { get; set; }

        public virtual ICollection<ClientCarRelation> ClientCarRelations { get; set; }
    }
}
