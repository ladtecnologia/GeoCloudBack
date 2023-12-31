using AutoMapper;
using GeoCloudAI.Application.Dtos;
using GeoCloudAI.Application.Contracts;
using GeoCloudAI.Persistence.Contracts;
using GeoCloudAI.Persistence.Models;

namespace GeoCloudAI.Application.Services
{
    public class ProfileService: IProfileService
    {
        private readonly IProfileRepository _profileRepository;

        private readonly IMapper _mapper;
        
        public ProfileService(IProfileRepository profileRepository,
                           IMapper mapper)
        {
            _profileRepository = profileRepository;
            _mapper = mapper;
        }

        public async Task<ProfileDto> Add(ProfileDto profileDto) 
        {
            try
            {
                //Map Dto > Class
                var addProfile = _mapper.Map<Domain.Classes.Profile>(profileDto); 
                //Add Profile
                var resultCode = await _profileRepository.Add(addProfile); // resultCode = "0" or "new Id"
                if (resultCode == 0) return null;
                //Get New Profile
                var result = await _profileRepository.GetById(resultCode);
                if (result == null) return null;
                //Map Class > Dto
                var resultDto = _mapper.Map<ProfileDto>(result);
                return resultDto;       
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            } 
        }

        public async Task<ProfileDto> Update(ProfileDto profileDto) 
        {
            try
            {
                //Check if exist Profile
                var existProfile = await _profileRepository.GetById(profileDto.Id);
                if (existProfile == null) return null;
                //Map Dto > Class
                var updateProfile = _mapper.Map<Domain.Classes.Profile>(profileDto);
                //Update Profile
                var resultCode = await _profileRepository.Update(updateProfile); // resultCode = "0" or "1"
                if (resultCode == 0) return null;
                //Get Updated Profile
                var result = await _profileRepository.GetById(updateProfile.Id);
                if (result == null) return null;
                //Map Class > Dto
                var resultDto = _mapper.Map<ProfileDto>(result);
                return resultDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            } 
        }

        public async Task<int> Delete(int profileId) 
        {
            try
            {
                return await _profileRepository.Delete(profileId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            } 
        }

        public async Task<PageList<ProfileDto>> Get(PageParams pageParams) 
        {
            try
            {
                var profiles = await _profileRepository.Get(pageParams);
                if (profiles == null) return null;
                //Map Class > Dto
                var result = _mapper.Map<PageList<ProfileDto>>(profiles);
                result.TotalCount  = profiles.TotalCount;
                result.CurrentPage = profiles.CurrentPage;
                result.PageSize    = profiles.PageSize;
                result.TotalPages  = profiles.TotalPages;

                return result;         
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }   
        }

        public async Task<ProfileDto> GetById(int profileId) 
        {
            try
            {
                var profile = await _profileRepository.GetById(profileId);
                if (profile == null) return null;
                //Map Class > Dto
                var result = _mapper.Map<ProfileDto>(profile);
                return result;         
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }  
        }
    }
}