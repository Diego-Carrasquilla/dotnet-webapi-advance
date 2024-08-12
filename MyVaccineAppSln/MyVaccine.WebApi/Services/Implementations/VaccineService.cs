using MyVaccine.WebApi.Dtos;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;
using MyVaccine.WebApi.Services.Contracts;
using AutoMapper;
using MyVaccine.WebApi.Dtos.Vaccine;

namespace MyVaccine.WebApi.Services.Implementations
{
    public class VaccineService : IVaccineService
    {
        private readonly IVaccineRepository _repository;
        private readonly IMapper _mapper;

        public VaccineService(IVaccineRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<VaccineResponseDto> GetById(int id)
        {
            var vaccine = await _repository.GetById(id);
            return _mapper.Map<VaccineResponseDto>(vaccine);
        }

        public async Task<IEnumerable<VaccineResponseDto>> GetAll()
        {
            var vaccines = await _repository.GetAll();
            return _mapper.Map<IEnumerable<VaccineResponseDto>>(vaccines);
        }

        public async Task<VaccineResponseDto> Add(VaccineRequestDto request)
        {
            var vaccine = _mapper.Map<Vaccine>(request);
            await _repository.Add(vaccine);
            return _mapper.Map<VaccineResponseDto>(vaccine);
        }

        public async Task<VaccineResponseDto> Update(VaccineRequestDto request, int id)
        {
            var vaccine = await _repository.GetById(id);
            if (vaccine == null)
            {
                throw new Exception("Vaccine not found");
            }
            _mapper.Map(request, vaccine);
            await _repository.Update(vaccine);
            return _mapper.Map<VaccineResponseDto>(vaccine);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}
