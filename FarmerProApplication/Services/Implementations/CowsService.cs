using AutoMapper;
using FarmerProApplication.Dtos.Cow;
using FarmerProApplication.Model;
using FarmerProApplication.Model.DatabaseModels;
using FarmerProApplication.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace FarmerProApplication.Services.Implementations
{
    public class CowsService : ICowsService
    {
        private readonly ApplicationDatabaseContext _context;
        private readonly IMapper _mapper;

        public CowsService(ApplicationDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Add(CreateCowDto createCow)
        {
            var cow = _mapper.Map<Cow>(createCow);

            _context.Cows.Add(cow);

            _context.SaveChanges();
        }

        public CowDto Get(int cowId)
        {
            var cow = _context.Cows.FirstOrDefault(cow => cow.Id == cowId);
            var cowDto = _mapper.Map<CowDto>(cow);
            return cowDto;
        }

        public List<CowDto> GetAll()
        {
            var cows = _context.Cows.ToList();
            var cowDtos = _mapper.Map<List<CowDto>>(cows);
            return cowDtos;
        }

        public void Remove(int cowId)
        {
            var cow = _context.Cows.FirstOrDefault(cow => cow.Id == cowId);
            _context.Cows.Remove(cow);
            _context.SaveChanges();
        }

        public void Update(int cowId, CreateCowDto updateCow)
        {
            var cow = _context.Cows.FirstOrDefault(cow => cow.Id == cowId);
            cow = _mapper.Map(updateCow, cow);
            _context.Update(cow);
            _context.SaveChanges();
        }
    }
}
