using System;
using System.Collections.Generic;
using System.Text;

namespace FarmerProApplication.Dtos.Korm
{
    public class StateKormDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public double Count { get; set; }
        public double Energy { get; set; }
        public double RawMaterial { get; set; }
        public double Protein { get; set; }
    }
}
