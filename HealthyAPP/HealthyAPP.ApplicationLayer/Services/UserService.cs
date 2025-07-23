using HealthyAPP.ApplicationLayer.Contract;
using HealthyAPP.ApplicationLayer.DTOs.User;
using HealthyAPP.DomainLayer.Entities;
using HealthyAPP.InfrastructureLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyAPP.ApplicationLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<UserDTO>> GetAllUsers()
        {
            var users = await _unitOfWork.Users.GetAllAsync();

            var usersResponse = users.Select(user => new UserDTO
            {
                User_id = user.User_id,
                Name = user.Name,
                Age = user.Age,
                Gender = user.Gender,
                Height = user.Height,
                Weight = user.Weight,
                Activity_Level = user.Activity_Level

            }).ToList();

            return usersResponse;
        }


        public async Task<UserDTO> GetUserById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("The id need to have a value");
            }
            var user = await _unitOfWork.Users.GetByIdAsync(id);

            var response = new UserDTO
            {
                User_id = user.User_id,
                Name = user.Name,
                Age = user.Age,
                Gender = user.Gender,
                Height = user.Height,
                Weight = user.Weight,
                Activity_Level = user.Activity_Level
            };

            return response;
        }


        public async Task<UserDTO> CreateUser(CreateUserDTO request)
        {
            if (request == null) { throw new ArgumentNullException("User cannot be null"); }

            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
                Age = request.Age,
                Gender = request.Gender,
                Height = request.Height,
                Weight = request.Weight,
                Activity_Level = request.Activity_Level

            };

            user = await _unitOfWork.Users.CreateAsync(user);

            await _unitOfWork.CompleteAsync();

            return new UserDTO
            {
                User_id = user.User_id,
                Name = user.Name,
                Age = user.Age,
                Gender = user.Gender,
                Height = user.Height,
                Weight = user.Weight,
                Activity_Level = user.Activity_Level
            };

        }


        public async Task/*<UserDTO> */UpdateUser(UpdateUserDTO request)
        {
            if (request == null || request.User_id <= 0)
            {
                throw new ArgumentException("Invalid User data.");
            }

            var existingUser = await _unitOfWork.Users.GetByIdAsync(request.User_id);

            if (existingUser == null)
            {
                throw new ArgumentException("User not found.");
            }

            existingUser.Name = request.Name;
            existingUser.Email = request.Email;
            existingUser.Password = request.Password;
            existingUser.Age = request.Age;
            existingUser.Gender = request.Gender;
            existingUser.Height = request.Height;
            existingUser.Weight = request.Weight;

            await _unitOfWork.Users.UpdateAsync(existingUser);
            await _unitOfWork.CompleteAsync();

            //return new UserDTO
            //{
            //    User_id = existingUser.User_id,
            //    Name = existingUser.Name,
            //    Email = existingUser.Email,
            //    Age = existingUser.Age,
            //    Gender = existingUser.Gender,
            //    Height = existingUser.Height,
            //    Weight = existingUser.Weight,
            //    Activity_Level = existingUser.Activity_Level
            //};
        }


        public async Task DeleteUser(int id)
        {
            var existingUser = await _unitOfWork.Users.GetByIdAsync(id);

            if (existingUser == null)
            {
                throw new InvalidDataException("User not found");
            }

            var result = await _unitOfWork.Users.DeleteAsync(id);

            if (result == false)
            {
                throw new InvalidDataException("Failed to delete User.");
            }

        }
    }
}
