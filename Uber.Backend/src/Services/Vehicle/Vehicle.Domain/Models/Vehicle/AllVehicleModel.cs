

using BuildingBlocks.Abstractions;
using Microsoft.AspNetCore.Http;
using Vehicle.Domain.ValueObjects;

namespace Vehicle.Domain.Models.Vehicle
{
    public class AllVehicleModel:Entity<VehicleId>
    {
        public string VehicleName { get; set; } = default!;
        public int MaxSeats { get; set; }
        public decimal BaseFare { get; set; }
        public decimal RatePerKM { get; set; }
        public string ImageUrl { get; set; } = default!;

        public static AllVehicleModel Create(VehicleId vehicleId, string vehicleName, int maxSeats, decimal baseFare, decimal ratePerKM, string imageUrl)
        {
            ArgumentNullException.ThrowIfNull(vehicleName);
            ArgumentNullException.ThrowIfNull(imageUrl);
            ArgumentNullException.ThrowIfNull(vehicleId);


            return new AllVehicleModel
            {
                Id = vehicleId,
                VehicleName = vehicleName,
                MaxSeats = maxSeats,
                BaseFare = baseFare,
                RatePerKM = ratePerKM,
                ImageUrl = imageUrl
            };
        }
    }
}
