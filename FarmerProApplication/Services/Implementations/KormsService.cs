using AutoMapper;
using FarmerProApplication.Dtos.Korm;
using FarmerProApplication.Model;
using FarmerProApplication.Model.DatabaseModels;
using FarmerProApplication.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace FarmerProApplication.Services.Implementations
{
    public class KormsService : IKormsService
    {
        private readonly ApplicationDatabaseContext _context;
        private readonly IMapper _mapper;

        public KormsService(ApplicationDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Add(CreateKormDto createKorm)
        {
            var korm = _mapper.Map<Korm>(createKorm);

            _context.Korms.Add(korm);

            _context.SaveChanges();
        }

        public KormDto Get(int kormId)
        {
            var korm = _context.Users.FirstOrDefault(korm => korm.Id == kormId);
            var kormDto = _mapper.Map<KormDto>(korm);
            return kormDto;
        }

        public List<KormDto> GetAll()
        {
            var korms = _context.Korms.ToList();
            var kormDtos = _mapper.Map<List<KormDto>>(korms);
            return kormDtos;
        }

        public void Remove(int kormId)
        {
            var korm = _context.Korms.FirstOrDefault(korm => korm.Id == kormId);
            _context.Korms.Remove(korm);
            _context.SaveChanges();
        }

        public void Update(int kormId, CreateKormDto updateKorm)
        {
            var korm = _context.Korms.FirstOrDefault(korm => korm.Id == kormId);
            korm = _mapper.Map(updateKorm, korm);
            _context.Korms.Update(korm);
            _context.SaveChanges();
        }
    }
}
