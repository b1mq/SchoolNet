using System;
using System.Collections.Generic;
using System.Text;
using SchoolNet.Domain.Entities.Pattern_Repository;

namespace SchoolNet.Domain.Entities
{
    public class Grade
    {
        public int Id { get; set; }
        public string Value { get; private set; } = string.Empty;
        public string? Comment { get; private set; }
        public int TeacherId { get; private set; }
        public int ClassSubjectId { get; private set; }
        public int StudentId { get;private  set; }
        public DateTime createdAt { get; private set; }

        protected Grade() { }
        private Grade(string value,string comment,int teacherId,int studentId,int subjectid)
        {
            Value = value;
            Comment = comment;
            TeacherId = teacherId;
            ClassSubjectId = subjectid;
            StudentId = studentId;
            createdAt = DateTime.UtcNow;
        }
        public static ResultGeneric<Grade> Create(string value,string? comment,int teacherId,int subjectid,int studentid)
        {
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
            return Result.Succes();
        }
        public Result UpdateGrade(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Result.Failure("Grade can not be empty");
            }
            Value = value.Trim();
            return Result.Succes();
        }
    }
}
