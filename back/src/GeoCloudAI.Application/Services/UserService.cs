using AutoMapper;
using GeoCloudAI.Application.Dtos;
using GeoCloudAI.Application.Contracts;
using GeoCloudAI.Domain.Classes;
using GeoCloudAI.Persistence.Contracts;
using GeoCloudAI.Persistence.Models;

namespace GeoCloudAI.Application.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;
        
        public UserService(IUserRepository userRepository,
                           IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Add(UserDto userDto) 
        {
            try
            {
                //Map Dto > Class
                var addUser = _mapper.Map<User>(userDto); 
                //Add User
                var resultCode = await _userRepository.Add(addUser); // resultCode = "0" or "new Id"
                if (resultCode == 0) return null;
                //Get New User
                var result = await _userRepository.GetById(resultCode);
                if (result == null) return null;
                //Map Class > Dto
                var resultDto = _mapper.Map<UserDto>(result);
                return resultDto;       
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            } 
        }

        public async Task<UserDto> Update(UserDto userDto) 
        {
            try
            {
                //Check if exist User
                var existUser = await _userRepository.GetById(userDto.Id);
                if (existUser == null) return null;
                //Map Dto > Class
                var updateUser = _mapper.Map<User>(userDto);
                //Update User
                var resultCode = await _userRepository.Update(updateUser); // resultCode = "0" or "1"
                if (resultCode == 0) return null;
                //Get Updated User
                var result = await _userRepository.GetById(updateUser.Id);
                if (result == null) return null;
                //Map Class > Dto
                var resultDto = _mapper.Map<UserDto>(result);
                return resultDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            } 
        }

        public async Task<int> Delete(int userId) 
        {
            try
            {
                return await _userRepository.Delete(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            } 
        }

        public async Task<PageList<UserDto>> Get(PageParams pageParams) 
        {
            try
            {
                var users = await _userRepository.Get(pageParams);
                if (users == null) return null;
                //Map Class > Dto
                var result = _mapper.Map<PageList<UserDto>>(users);
                result.TotalCount  = users.TotalCount;
                result.CurrentPage = users.CurrentPage;
                result.PageSize    = users.PageSize;
                result.TotalPages  = users.TotalPages;

                return result;         
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }   
        }

        public async Task<UserDto> GetById(int userId) 
        {
            try
            {
                var user = await _userRepository.GetById(userId);
                if (user == null) return null;
                //Map Class > Dto
                var result = _mapper.Map<UserDto>(user);
                return result;         
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }  
        }
    }
}