using FarmerProApplication.Dtos;
using FarmerProApplication.Dtos.Korm;
using FarmerProApplication.Dtos.Norm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FarmerProApplication.Services
{
    public class StateService
    {
        public NormDto Norm { get; set; }
        public List<StateKormDto> Korms { get; set; }
        public double CostRation { get; set; }

        public List<NutritionRationDto> CalculateNutrition()
        {
            var result = new List<NutritionRationDto>
            {
                new NutritionRationDto{
                    Name = "Протеин",
                    CurrentValue=Korms.Sum(korm=>korm.Protein*korm.Count),
                    NormValue = Norm.Protein,
                    Deviation = Norm.Protein-Korms.Sum(korm=>korm.Protein*korm.Count)
                },
                new NutritionRationDto{
                    Name = "СВ",
                    CurrentValue=Korms.Sum(korm=>korm.RawMaterial*korm.Count),
                    NormValue = Norm.RawMaterial,
                    Deviation = Norm.RawMaterial-Korms.Sum(korm=>korm.RawMaterial*korm.Count)
                },
                new NutritionRationDto{
                    Name = "Энергия",
                    CurrentValue=Korms.Sum(korm=>korm.Energy*korm.Count),
                    NormValue = Norm.Energy,
                    Deviation = Norm.Energy-Korms.Sum(korm=>korm.Energy*korm.Count)
                },

            };
            return result;

        }

        public double CalculateCostRation(int cowsCount, int days)
        {
            CostRation = Korms.Sum(korm => Convert.ToDouble(korm.Cost) * korm.Count) * cowsCount * days;
            return CostRation;
        }
    }
}
