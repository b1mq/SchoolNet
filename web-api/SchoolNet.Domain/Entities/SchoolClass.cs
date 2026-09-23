using System;
using System.Collections.Generic;
using System.Text;
using SchoolNet.Domain.Entities.BaseEntitie;
using SchoolNet.Domain.Entities.Pattern_Repository;
using SchoolNet.Domain.Enums;
using SchoolNet.Domain.Interfaces.Common;

namespace SchoolNet.Domain.Entities
{
    public class SchoolClass:AbstractEntity,ISoftDeletable
    {
        public string Name { get; private set; } = string.Empty;
        public string SchoolYear { get; private set; } = string.Empty;
        public bool isDeleted { get; private set; }
        private readonly List<User> _students = new List<User>(); // скрытый список
        public IReadOnlyCollection<User> Students => _students.AsReadOnly();
        private readonly List<ClassSubject> _classSubjects = new List<ClassSubject>();
        public IReadOnlyCollection<ClassSubject> ClassSubjects => _classSubjects.AsReadOnly();

        protected SchoolClass() { }
        
        private SchoolClass(string name, string schoolYear)
        {
            Name = name;
            SchoolYear = schoolYear;
        }
        public static ResultGeneric<SchoolClass> Create(string name, string schoolYear) // фабричный метод
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return ResultGeneric<SchoolClass>.Failure("Class name can not be empty");
            }

            if (string.IsNullOrWhiteSpace(schoolYear))
            {
                return ResultGeneric<SchoolClass>.Failure("School year can not be empty");
            }

            var schoolClass = new SchoolClass(name.Trim(), schoolYear.Trim());
            return ResultGeneric<SchoolClass>.Success(schoolClass);
        }
        public Result AddClassSubject(ClassSubject classSubject)
        {
            if (classSubject == null) return Result.Failure("ClassSubject cannot be null");

            if (_classSubjects.Any(cs => cs.SubjectId == classSubject.SubjectId))
            {
                return Result.Failure("This subject is already assigned to the class");
            }
            if(classSubject.isDeleted)
            {
                return Result.Failure("Deleted class subject can not be assigned");
            }

            _classSubjects.Add(classSubject);
            UpdateTimeStamp();
            return Result.Succes();
        }
        public Result AddStudent(User user)
        {
            if(user == null)
            {
                return Result.Failure("Student can not be empty");
            }
            if (user.Role != UserRole.Student)
            {
                return Result.Failure("Only users with role 'Student' can be added to a class");
            }

          
            if (_students.Any(s => s.Id == user.Id))
            {
                return Result.Failure("Student is already in this class");
            }
            _students.Add(user);
            user.AssignToClass(Id);
            UpdateTimeStamp();
            return Result.Succes();
        }
        public Result RemoveStudent(User user)
        {
            if (user == null) return Result.Failure("Student can not be null");

            var existingStudent = _students.FirstOrDefault(s => s.Id == user.Id);
            if (existingStudent == null)
            {
                return Result.Failure("Student is not in this class");
            }
            var result = existingStudent.RemoveFromClass();
            if(result.IsFailure)
            {
                return result;
            }

            _students.Remove(existingStudent);
            UpdateTimeStamp();
            return Result.Succes();
        }
        public Result UpdateDetails(string name, string schoolYear)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(schoolYear))
            {
                return Result.Failure("Name and school year can not be empty");
            }

            Name = name.Trim();
            SchoolYear = schoolYear.Trim();
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
