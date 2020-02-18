using FarmerProApplication.Dtos.Cow;
using System.Collections.Generic;

namespace FarmerProApplication.Services.Contracts
{
    public interface ICowsService
    {
        List<CowDto> GetAll();
        CowDto Get(int cowId);
        void Add(CreateCowDto createCow);
        void Update(int cowId, CreateCowDto updateCow);
        void Remove(int cowId);
    }
}
