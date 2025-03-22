
namespace Vehicle.Application.Vehicle.Queries.CheckVehicle;
public record CheckVehicleCreatedQuery(Guid DriverId):IQuery<CheckVehicleCreatedResult>;
public record CheckVehicleCreatedResult(bool Exists);

