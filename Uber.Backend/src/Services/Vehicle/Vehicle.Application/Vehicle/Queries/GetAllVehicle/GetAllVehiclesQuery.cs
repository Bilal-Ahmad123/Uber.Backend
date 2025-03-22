

namespace Vehicle.Application.Vehicle.Queries.GetVehicle;
public record GetAllVehiclesQuery():IQuery<GetAllVehiclesResult>;
public record GetAllVehiclesResult(IEnumerable<VehicleDto> Vehicles);
