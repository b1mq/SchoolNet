using System;
using System.Collections.Generic;
using System.Text;
using SchoolNet.Domain.Entities.BaseEntitie;
using SchoolNet.Domain.Entities.Pattern_Repository;
using SchoolNet.Domain.Enums;
using SchoolNet.Domain.Interfaces.Common;

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
                if(DateOfBirth > today.AddYears(-age))
                {
                    age--;
                }
                return age;

            } 
        }
        public string PasswordHash { get; private set; } = string.Empty;
        public bool isDeleted { get; private set; } = false;
        public UserRole Role { get; private set; }
        public int? ClassId { get; private set; } // для учителей
        public SchoolClass? Class { get; private set; }
        protected User() { }
        private User(string firstName, string lastName, DateOnly dateOfBirth, string passwordHash, UserRole role)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            PasswordHash = passwordHash;
            Role = role;
        }

        public static ResultGeneric<User> Create(string firstName, string lastName, DateOnly dateOfBirth, string passwordHash, UserRole role)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                return ResultGeneric<User>.Failure("First and last names can not be empty");
            }

            

            if (string.IsNullOrWhiteSpace(passwordHash))
            {
                return ResultGeneric<User>.Failure("Password hash can not be empty");
            }

            var user = new User(firstName.Trim(), lastName.Trim(),  dateOfBirth, passwordHash, role);
            return ResultGeneric<User>.Success(user);
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
