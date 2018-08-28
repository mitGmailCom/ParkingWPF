using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace ParkingWPF
{
    public class ParkingContext: DbContext
    {
        public ParkingContext():base("connect")
        {
            Database.SetInitializer<ParkingContext>(new CreateDatabaseIfNotExists<ParkingContext>());
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<HistoryAddedCars> HistoryAddedCars { get; set; }
        public DbSet<HistoryDeletedCars> HistoryDeletedCars { get; set; }
        public DbSet<BalanceParking> BalanceParking { get; set; }
        public DbSet<ClientCarRelation> ClientCarRelation { get; set; }
    }
}
