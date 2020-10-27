using System;
using System.Collections.Generic;

namespace API.Entitys
{
    public partial class Species
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string Classification { get; set; }
        public string Designation { get; set; }
        public short AverageHeight { get; set; }
        public string SkinColors { get; set; }
        public string HairColors { get; set; }
        public string EyeColors { get; set; }
        public short? AverageLifespan { get; set; }
        public string Homeworld { get; set; }
        public DateTime Created { get; set; }
        public byte[] Edited { get; set; }
        public string Language { get; set; }
    }
}
