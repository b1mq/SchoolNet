using System;
using System.Collections.Generic;
using System.Text;
using SchoolNet.Domain.Entities.BaseEntitie;
using SchoolNet.Domain.Entities.Pattern_Repository;
using SchoolNet.Domain.Interfaces.Common;

namespace SchoolNet.Domain.Entities
{
    public class ClassSubject:AbstractEntity,ISoftDeletable
    {
      
        public int ClassId { get; private set; }
        public int SubjectId { get; private set; }
        public bool isDeleted { get; private set; }
        public SchoolClass? SClass { get; private set; }
        public Subject? Subject { get; private set; }
        protected  ClassSubject() { }
        private ClassSubject(int classid,int subjectid)
        {
            SubjectId = subjectid;
            ClassId = classid;
        }
        public static ResultGeneric<ClassSubject> Create(int classid,int subjectid)
        {
            if (classid <= 0)
            {
                return ResultGeneric<ClassSubject>.Failure("Class id can not be negative or zero");
            }

            if (subjectid <= 0)
            {
                return ResultGeneric<ClassSubject>.Failure("Subject id can not be negative or zero");
            }
            var classSubject = new ClassSubject(classid, subjectid);
            return ResultGeneric<ClassSubject>.Success(classSubject);
        }
        public void SoftDelete()
        {
            isDeleted = true;
        }
    
    }
}
