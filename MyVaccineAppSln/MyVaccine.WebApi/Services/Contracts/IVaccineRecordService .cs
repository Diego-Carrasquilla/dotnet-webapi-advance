using MyVaccine.WebApi.Dtos.Models_Dtos.VaccineRecordDto;

namespace MyVaccine.WebApi.Services.Contracts
{
    namespace MyVaccine.WebApi.Services.Contracts
    {
        public interface IVaccineRecordService
        {
            Task<VaccineRecordResponseDto> GetById(int id);
            Task<IEnumerable<VaccineRecordResponseDto>> GetAll();
            Task<VaccineRecordResponseDto> Add(VaccineRecordRequestDto request);
            Task<VaccineRecordResponseDto> Update(VaccineRecordRequestDto request, int id);
            Task Delete(int id);
        }
    }

}
