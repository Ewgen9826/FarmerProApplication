using FarmerProApplication.Dtos.Korm;
using System.Collections.Generic;

namespace FarmerProApplication.Services.Contracts
{
    public interface IKormsService
    {
        List<KormDto> GetAll();
        KormDto Get(int kormId);
        void Add(CreateKormDto createKorm);
        void Update(int kormId, CreateKormDto updateKorm);
        void Remove(int kormId);
    }
}
