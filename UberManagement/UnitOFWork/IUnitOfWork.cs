using UberManagement.Models;
using UberManagement.Repos.Interfaces;

namespace UberManagement.UnitOFWork
{
    public interface IUnitOfWork
    {
        IUserRepo UserRepo { get; }
        IRidesRepo RideRepo { get; }
        IGenericRepo<Vehicle> VehicleRepo { get; }
        int Save();
    }
}
