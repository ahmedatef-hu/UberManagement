using UberManagement.Data;
using UberManagement.Models;
using UberManagement.Repos.Interfaces;

namespace UberManagement.UnitOFWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;
        public IUserRepo UserRepo { get; }

        public IGenericRepo<Vehicle> VehicleRepo { get; }

        public IRidesRepo RideRepo {  get; }

        public UnitOfWork(AppDbContext context, IUserRepo userRepo, IGenericRepo<Vehicle> VehicleRepo, IRidesRepo rideRepo)
        {
            this.context = context;
            UserRepo = userRepo;
            this.VehicleRepo = VehicleRepo;
            RideRepo = rideRepo;
        }

        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
