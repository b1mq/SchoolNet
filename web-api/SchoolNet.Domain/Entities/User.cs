using System;
using System.Collections.Generic;
using System.Text;
using SchoolNet.Domain.Entities.BaseEntitie;
using SchoolNet.Domain.Entities.Pattern_Repository;
using SchoolNet.Domain.Enums;
using SchoolNet.Domain.Interfaces.Common;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SchoolNet.Domain.Entities
{
    public class User:AbstractEntity,ISoftDeletable
    {
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public DateOnly DateOfBirth { get; private set; }
        public int Age { get
            {
                var today = DateOnly.FromDateTime(DateTime.UtcNow);
                var age = today.Year - DateOfBirth.Year;
                if (DateOfBirth > today.AddYears(-age))
                {
                    age--;
                }
                return age;

            } 
            
        }
        public string PasswordHash { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public bool isDeleted { get; private set; } = false;
        public UserRole Role { get; private set; }
        public int? ClassId { get; private set; } // для учителей
        public SchoolClass? Class { get; private set; }
        public string? RefreshTokenHash { get; private set; } 
        public DateTime? RefreshTokenExpiryTime { get; private set; }
        protected User() { }
        private User(string firstName, string lastName, DateOnly dateOfBirth, string passwordHash, UserRole role,string email)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            PasswordHash = passwordHash;
            Role = role;
            Email = email;
        }

        public static ResultGeneric<User> Create(string firstName, string lastName, DateOnly dateOfBirth, string passwordHash, UserRole role, string email)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                return ResultGeneric<User>.Failure("First and last names can not be empty");
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                return ResultGeneric<User>.Failure("email  can not be empty");
            }

            if (string.IsNullOrWhiteSpace(passwordHash))
            {
                return ResultGeneric<User>.Failure("Password hash can not be empty");
            }

            var user = new User(firstName.Trim(), lastName.Trim(),  dateOfBirth, passwordHash, role,email);
            return ResultGeneric<User>.Success(user);
        }
        public Result UpdatePasswordHash(string newPassHash)
        {
            if (string.IsNullOrWhiteSpace(newPassHash))
            {
                return Result.Failure("Password hash can not be empty");
            }
            PasswordHash = newPassHash;
            UpdateTimeStamp();
            return Result.Succes();
        }
        public Result UpdateRefreshToken(string refreshTokenHash,DateTime expireTime)
        {
            if (string.IsNullOrWhiteSpace(refreshTokenHash))
            {
                return Result.Failure("Refresh token hash cannot be empty");
            }

            if (expireTime <= DateTime.UtcNow)
            {
                return Result.Failure("Expiry time must be in the future");
            }
            RefreshTokenHash = refreshTokenHash;
            RefreshTokenExpiryTime = expireTime;
            UpdateTimeStamp();
            return Result.Succes();

        }
        public Result RevokeRefreshToken()
        {
            RefreshTokenHash = null;
            RefreshTokenExpiryTime = null;
            UpdateTimeStamp();
            return Result.Succes();
        }
        public Result AssignToClass(int classId)
        {
            if (classId <= 0)
            {
                return Result.Failure("Class id can not be negative or zero");
            }

            ClassId = classId;
            UpdateTimeStamp();
            return Result.Succes();
        }

        public Result RemoveFromClass()
        {
            ClassId = null;
            UpdateTimeStamp();
            return Result.Succes();
        }

        public void SoftDelete()
        {
            isDeleted = true;
            UpdateTimeStamp();
        }
    }
}
