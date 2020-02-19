using AutoMapper;
using FarmerProApplication.Dtos.Norm;
using FarmerProApplication.Model;
using FarmerProApplication.Model.DatabaseModels;
using FarmerProApplication.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FarmerProApplication.Services.Implementations
{
    public class NormsService : INormsService
    {
        private readonly ApplicationDatabaseContext _context;
        private readonly IMapper _mapper;

        public NormsService(ApplicationDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Add(CreateNormDto createNorm)
        {
            var norm = _mapper.Map<Norm>(createNorm);

            _context.Norms.Add(norm);

            _context.SaveChanges();
        }

        public NormDto Get(int normId)
        {
            var norm = _context.Norms.FirstOrDefault(norm => norm.Id == normId);
            var normDto = _mapper.Map<NormDto>(norm);
            return normDto;
        }

        public List<NormDto> GetAll()
        {
            var norms = _context.Norms.ToList();
            var normDtos = _mapper.Map<List<NormDto>>(norms);
            return normDtos;
        }

        public NormDto GetByInterval(double minWeigth, double maxWeigth, double minProductivity, double maxProductivity)
        {
            var korm = _context.Cows.Include(cow => cow.Norm)
                .FirstOrDefault(cow => cow.Weight >= minWeigth && cow.Weight <= maxWeigth && cow.Productivity >= minProductivity && cow.Productivity <= maxProductivity);
            var normDto = new NormDto
            {
                Id = korm.Norm.Id,
                Energy = korm.Norm.Energy,
                Name = korm.Norm.Name,
                Protein = korm.Norm.Protein,
                RawMaterial = korm.Norm.RawMaterial
            };
            return normDto;
        }

        public void Remove(int normId)
        {
            var norm = _context.Norms.FirstOrDefault(norm => norm.Id == normId);
            _context.Norms.Remove(norm);
            _context.SaveChanges();
        }

        public void Update(int normId, CreateNormDto updateNorm)
        {
            var norm = _context.Norms.FirstOrDefault(norm => norm.Id == normId);
            norm = _mapper.Map(updateNorm, norm);
            _context.Update(norm);
            _context.SaveChanges();
        }
    }
}
