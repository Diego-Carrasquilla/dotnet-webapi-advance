using AutoMapper;
using MyVaccine.WebApi.Dtos;
using MyVaccine.WebApi.Dtos.Models_Dtos.VaccineCategory;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;
using MyVaccine.WebApi.Services.Contracts;

namespace MyVaccine.WebApi.Services.Implementations
{
    public class VaccineCategoryService : IVaccineCategoryService
    {
        private readonly IVaccineCategoryRepository _repository;
        private readonly IMapper _mapper;

        public VaccineCategoryService(IVaccineCategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<VaccineCategoryResponseDto> GetById(int id)
        {
            var vaccineCategory = await _repository.GetById(id);
            return _mapper.Map<VaccineCategoryResponseDto>(vaccineCategory);
        }

        public async Task<IEnumerable<VaccineCategoryResponseDto>> GetAll()
        {
            var vaccineCategories = await _repository.GetAll();
            return _mapper.Map<IEnumerable<VaccineCategoryResponseDto>>(vaccineCategories);
        }

        public async Task<VaccineCategoryResponseDto> Add(VaccineCategoryRequestDto request)
        {
            var vaccineCategory = _mapper.Map<VaccineCategory>(request);
            await _repository.Add(vaccineCategory);
            return _mapper.Map<VaccineCategoryResponseDto>(vaccineCategory);
        }

        public async Task<VaccineCategoryResponseDto> Update(VaccineCategoryRequestDto request, int id)
        {
            var vaccineCategory = await _repository.GetById(id);
            if (vaccineCategory == null)
            {
                throw new Exception("VaccineCategory not found");
            }
            _mapper.Map(request, vaccineCategory);
            await _repository.Update(vaccineCategory);
            return _mapper.Map<VaccineCategoryResponseDto>(vaccineCategory);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}
