using FarmerProApplication.Dtos.Norm;
using System.Collections.Generic;

namespace FarmerProApplication.Services.Contracts
{
    public interface INormsService
    {
        List<NormDto> GetAll();
        NormDto Get(int normId);
        void Add(CreateNormDto createNorm);
        void Update(int normId, CreateNormDto updateNorm);
        void Remove(int normId);
        NormDto GetByInterval(double minWeigth, double maxWeigth, double minProductivity, double maxProductivity);
    }
}
