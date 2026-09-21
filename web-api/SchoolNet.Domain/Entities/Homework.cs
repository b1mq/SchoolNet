using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic;
using SchoolNet.Domain.Entities.Pattern_Repository;

namespace SchoolNet.Domain.Entities
{
    public class Homework
    {
        public int Id { get; set; }
        public string Title { get; private set; } = string.Empty;
        public string Content { get; private set; } = string.Empty;
        public int ClassSubjectId { get; private set; }
        public int TeacherId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public DateTime DueDate { get; private set; }
        protected Homework() { }
        private Homework(string title,string content,int classsubjectid,int teacherid,DateTime dueDate)
        {
            Title = title;
            Content = content;
            ClassSubjectId = classsubjectid;
            TeacherId = teacherid;
            CreatedAt = DateTime.UtcNow;
            DueDate = dueDate;
        }
        public static ResultGeneric<Homework> Create(string title,string content,int classsubjectid,int teacherid,DateTime dueDate)
        {
            if(string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(content))
            {
                return ResultGeneric<Homework>.Failure("Given argument can not be empty");
            }
            if(dueDate < DateTime.UtcNow)
            {
                return ResultGeneric<Homework>.Failure("Due time can not be negative than time now");
            }
            var homework = new Homework(title,content,classsubjectid,teacherid,dueDate);
            return ResultGeneric<Homework>.Success(homework);

        }
        public Result ChangeContent(string newContent)
        {
            if(string.IsNullOrWhiteSpace(newContent))
            {
                return Result.Failure("New Content is empty or white space");
            }
            Content = newContent;
            UpdatedAt = DateTime.UtcNow;
            return Result.Succes();
        }
        public Result Update(string title,string content,DateTime dueDate)
        {
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(content))
            {

                return Result.Failure("Given argument can not be empty");
            }
            Title = title.Trim();
            Content = content.Trim();
            DueDate = dueDate;
            UpdatedAt = DateTime.UtcNow;
            return Result.Succes();

        }
        public Result ChangeDueDate(DateTime newdueDate)
        {
            if(newdueDate < DateTime.UtcNow || newdueDate == DueDate)
            {
                return Result.Failure("The given argument for new due date is invalid");
            }
            DueDate = newdueDate;
            UpdatedAt = DateTime.UtcNow;
            return Result.Succes();
        }

    }
}
