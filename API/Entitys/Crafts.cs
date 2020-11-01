using System;
using System.Collections.Generic;

namespace API.Entitys
{
    public partial class Crafts
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public int CostInCredits { get; set; }
        public short Length { get; set; }
        public short MaxAtmospheringSpeed { get; set; }
        public string Crew { get; set; }
        public string Passengers { get; set; }
        public int CargoCapacity { get; set; }
        public string Consumables { get; set; }
        public short HyperdriveRating { get; set; }
        public short Mglt { get; set; }
        public string StarshipClass { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public string VehicleType { get; set; }
    }
}
