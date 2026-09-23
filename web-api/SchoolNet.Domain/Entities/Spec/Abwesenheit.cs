using System;
using System.Collections.Generic;
using System.Text;
using SchoolNet.Domain.Enums;
using SchoolNet.Domain.Entities.Pattern_Repository;
using SchoolNet.Domain.Entities.BaseEntitie;
using SchoolNet.Domain.Interfaces.Common;
namespace SchoolNet.Domain.Entities.Spec
{
    public class Abwesenheit:AbstractEntity,ISoftDeletable
    {
       
        public int StudentId { get; private set; }
        public int? ScheduleId { get; private set; } // количество уроков
        public DateTime Date { get; private set; }
        public string? Reason { get; private set; }
        public AbsenceStatus Status { get; private set; }
        public bool isDeleted { get; private set; } = false;
        protected Abwesenheit() { }
        private Abwesenheit(int studentId,int? scheduleId, DateTime date, string? reason,AbsenceStatus status)
        {
            StudentId = studentId;
            ScheduleId = scheduleId;
            Date = date.Date;
            Status = status;
            Reason = reason;

        }
        public static ResultGeneric<Abwesenheit> Create(int studentId,int? scheduleId,DateTime date,string? reason,AbsenceStatus status)
        {
            if (studentId <= 0)
            {
                return ResultGeneric<Abwesenheit>.Failure("Student id is null");
            }
            if(date < DateTime.UtcNow)
            {
                return ResultGeneric<Abwesenheit>.Failure("Given date is false");
            }
            var abwesenheit = new Abwesenheit(studentId,scheduleId,date,reason,status);
            return ResultGeneric<Abwesenheit>.Success(abwesenheit);
            
        }
        public Result SetReason(string reason)
        {
            if(string.IsNullOrWhiteSpace(reason))
            {
                return Result.Failure("Given reason is empty");
            }
            Reason = reason;
            return Result.Succes();
        }
        public Result SetStatus(AbsenceStatus status)
        {
            Status = status;
            return Result.Succes();
        }
        public void SoftDelete()
        {
            isDeleted = true;
            UpdateTimeStamp();
        }

    }
}
