using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyVaccine.WebApi.Dtos;
using MyVaccine.WebApi.Dtos.Models_Dtos.VaccineRecordDto;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;
using MyVaccine.WebApi.Repositories.Implementations;
using MyVaccine.WebApi.Services.Contracts.MyVaccine.WebApi.Services.Contracts;

namespace MyVaccine.WebApi.Services.Implementations
{
    public class VaccineRecordService : IVaccineRecordService
    {
        private readonly MyVaccineAppDbContext _context;
        private readonly IVaccineRecordRepository _repository;
        private readonly IMapper _mapper;
        private readonly IVaccineRepository _VaccineRepository;

        public VaccineRecordService(IVaccineRecordRepository repository, IMapper mapper, MyVaccineAppDbContext context, IVaccineRepository vaccineRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _context = context;
            _VaccineRepository = vaccineRepository;
        }

        public async Task<VaccineRecordResponseDto> GetById(int id)
        {
            var vaccineRecord = await _repository.GetByIdWithDetails(id);
            return _mapper.Map<VaccineRecordResponseDto>(vaccineRecord);
        }

        public async Task<IEnumerable<VaccineRecordResponseDto>> GetAll()
        {
            var vaccineRecords = await _repository.GetAll().ToListAsync(); 
            return _mapper.Map<IEnumerable<VaccineRecordResponseDto>>(vaccineRecords);
        }


        public async Task<VaccineRecordResponseDto> Add(VaccineRecordRequestDto request)
        {
            var vaccine = await _VaccineRepository.GetById(request.VaccineId); 
            if (vaccine == null)
            {
                throw new Exception("Vaccine not found");
            }

            var vaccineRecord = _mapper.Map<VaccineRecord>(request);
            await _repository.Add(vaccineRecord);

            var response = _mapper.Map<VaccineRecordResponseDto>(vaccineRecord);
            response.RequiresBooster = vaccine.RequireBooster && (DateTime.Now - request.DateAdministered).TotalDays > 365; 

            return response;
        }


        public async Task<VaccineRecordResponseDto> Update(VaccineRecordRequestDto request, int id)
        {
            var vaccineRecord = await _repository.GetByIdWithDetails(id);
            if (vaccineRecord == null)
            {
                throw new Exception("VaccineRecord not found");
            }

            _mapper.Map(request, vaccineRecord);
            await _repository.Update(vaccineRecord);
            return _mapper.Map<VaccineRecordResponseDto>(vaccineRecord);
        }

        public async Task Delete(int id)
        {
            var VaccineRecord = await _context.VaccineRecords.FindAsync(id);
            if (VaccineRecord != null)
            {
                _context.VaccineRecords.Remove(VaccineRecord);
                await _context.SaveChangesAsync();
            }
        }

    }
}

