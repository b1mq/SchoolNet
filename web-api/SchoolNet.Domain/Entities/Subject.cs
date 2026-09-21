using System;
using System.Collections.Generic;
using System.Text;
using SchoolNet.Domain.Entities.BaseEntitie;
using SchoolNet.Domain.Entities.Pattern_Repository;
using SchoolNet.Domain.Interfaces.Common;

namespace SchoolNet.Domain.Entities
{
    public class Subject:AbstractEntity,ISoftDeletable
    {
        public string Title { get; private set; } = string.Empty;

        public bool isDeleted { get; private set; }
        protected Subject() { }
        private Subject(string title)
        {
            Title = title;
        }
        public static ResultGeneric<Subject> Create(string title)
        {
            if(string.IsNullOrWhiteSpace(title))
            {
                return ResultGeneric<Subject>.Failure("title is empty");
            }
            var subject = new Subject(title);
            return ResultGeneric<Subject>.Success(subject);
        }
        public void SoftDelete()
        {
            isDeleted = true;

        }
    }
}
