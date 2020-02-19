using System;
using System.Collections.Generic;
using System.Text;

namespace FarmerProApplication.Dtos.Korm
{
    public class ChoiceKormDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public bool IsCheck { get; set; }
        public double Energy { get; set; }
        public double RawMaterial { get; set; }
        public double Protein { get; set; }
    }
}
