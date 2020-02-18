using System;
using System.Collections.Generic;
using System.Text;

namespace FarmerProApplication.Dtos.Cow
{
    public class CowDto
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public double Weight { get; set; }
        public double Productivity { get; set; }
    }
}
