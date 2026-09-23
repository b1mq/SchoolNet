using System;
using System.Collections.Generic;
using System.Text;
using SchoolNet.Domain.Entities.BaseEntitie;
using SchoolNet.Domain.Entities.Pattern_Repository;
using SchoolNet.Domain.Interfaces.Common;

namespace SchoolNet.Domain.Entities.Spec
{
    public class Grade:AbstractEntity,ISoftDeletable
    {
       
        public string Value { get; private set; } = string.Empty;
        public string? Comment { get; private set; }
        public int TeacherId { get; private set; }
        public int ClassSubjectId { get; private set; }
        public int StudentId { get;private  set; }
        public bool isDeleted { get; private set; } = false;

        protected Grade() { }
        private Grade(string value,string comment,int teacherId,int studentId,int subjectid)
        {
            Value = value;
            Comment = comment;
            TeacherId = teacherId;
            ClassSubjectId = subjectid;
            StudentId = studentId;
            CreatedAt = DateTime.UtcNow;
        }
        public static ResultGeneric<Grade> Create(string value,string? comment,int teacherId,int subjectid,int studentid)
        {
            if(teacherId < 0)
            {
                return ResultGeneric<Grade>.Failure("Teacher id can not be empty");
            }
            if(subjectid < 0)
            {
                return ResultGeneric<Grade>.Failure("Subject id can not be empty");
            }
            if(studentid < 0)
            {
                return ResultGeneric<Grade>.Failure("Student id can not be empty");
            }
            if(string.IsNullOrWhiteSpace(value))
            {
                return ResultGeneric<Grade>.Failure("Grade can not be empty");
            }
            if (value.Length > 3)
            {
                return ResultGeneric<Grade>.Failure("Grade format is false.");
            }
            var grade = new Grade(value.Trim(),comment,teacherId,studentid,subjectid);
            return ResultGeneric<Grade>.Success(grade);
        }
        public Result AddComment(string comment)
        {
            if(string.IsNullOrWhiteSpace(comment))
            {
                return Result.Failure("Given comment is empty");

            }
            Comment = comment;
            UpdateTimeStamp();
            return Result.Succes();
        }
        public Result UpdateGrade(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Result.Failure("Grade can not be empty");
            }
            Value = value.Trim();
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
