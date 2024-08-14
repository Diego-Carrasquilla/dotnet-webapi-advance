using AutoMapper;
using MyVaccine.WebApi.Dtos.Models_Dtos.FamilyGroup;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;
using MyVaccine.WebApi.Services.Contracts;

namespace MyVaccine.WebApi.Services.Implementations
{
    public class FamilyGroupService : IFamilyGroupService
    {
        private readonly IFamilyGroupRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public FamilyGroupService(IFamilyGroupRepository repository, IUserRepository userRepository, IMapper mapper)
        {
            _repository = repository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<FamilyGroupResponseDto> GetById(int id)
        {
            var familyGroup = await _repository.GetByIdWithUsers(id);
            return _mapper.Map<FamilyGroupResponseDto>(familyGroup);
        }

        public async Task<IEnumerable<FamilyGroupResponseDto>> GetAll()
        {
            var familyGroups = await _repository.GetAll();
            return _mapper.Map<IEnumerable<FamilyGroupResponseDto>>(familyGroups);
        }

        public async Task<FamilyGroupResponseDto> Add(FamilyGroupRequestDto request)
        {
            var familyGroup = _mapper.Map<FamilyGroup>(request);
            await _repository.Add(familyGroup);
            return _mapper.Map<FamilyGroupResponseDto>(familyGroup);
        }

        public async Task<FamilyGroupResponseDto> Update(FamilyGroupRequestDto request, int id)
        {
            var familyGroup = await _repository.GetById(id);
            if (familyGroup == null)
            {
                throw new Exception("FamilyGroup not found");
            }
            if (familyGroup != null)
            {
                // Actualiza el nombre del grupo familiar
                familyGroup.Name = request.Name;

                _mapper.Map(request, familyGroup);

                await _repository.Update(familyGroup);
            }

            return _mapper.Map<FamilyGroupResponseDto>(familyGroup);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<FamilyGroupResponseDto> AddUserToFamilyGroup(int familyGroupId, int userId)
        {
            var familyGroup = await _repository.GetByIdWithUsers(familyGroupId);
            if (familyGroup == null)
            {
                throw new Exception("FamilyGroup not found");
            }

            var user = await _userRepository.GetById(userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            familyGroup.Users.Add(user);
            await _repository.Update(familyGroup);

            return _mapper.Map<FamilyGroupResponseDto>(familyGroup);
        }
    }
}


