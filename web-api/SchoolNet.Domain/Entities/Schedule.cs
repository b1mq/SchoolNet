using System;
using System.Collections.Generic;
using System.Text;
using SchoolNet.Domain.Entities.BaseEntitie;
using SchoolNet.Domain.Entities.Pattern_Repository;
using SchoolNet.Domain.Interfaces.Common;

namespace SchoolNet.Domain.Entities
{
    public class Schedule:AbstractEntity,ISoftDeletable
    {
        public int ClassSubjectId { get; private set; }
        public int TeacherId { get; private set; }
        public DayOfWeek Day { get; private set; }
        public int? RoomId { get; private set; }
        public string TimeSlot { get; private set; } = string.Empty;
        public bool isDeleted { get; private set; }
        protected Schedule() { }
        private Schedule(int classSubjectId, int teacherId, int? roomId, DayOfWeek day, string timeSlot)
        {
            ClassSubjectId = classSubjectId;
            TeacherId = teacherId;
            RoomId = roomId;
            Day = day;
            TimeSlot = timeSlot;
        }
        public static ResultGeneric<Schedule> Create(int classSubjectId, int teacherId, int? roomId, DayOfWeek day, string timeSlot)
        {
            if (classSubjectId <= 0)
            {
                return ResultGeneric<Schedule>.Failure("ClassSubject id can not be negative or zero");
            }

            if (teacherId <= 0)
            {
                return ResultGeneric<Schedule>.Failure("Teacher id can not be negative or zero");
            }

            if (roomId.HasValue && roomId.Value <= 0)
            {
                return ResultGeneric<Schedule>.Failure("Room id can not be negative");
            }

            if (string.IsNullOrWhiteSpace(timeSlot))
            {
                return ResultGeneric<Schedule>.Failure("Time slot can not be empty");
            }

            var schedule = new Schedule(classSubjectId, teacherId, roomId, day, timeSlot.Trim());
            return ResultGeneric<Schedule>.Success(schedule);
        }
        public Result UpdateTimeSlot(string newTimeSlot)
        {
            if(string.IsNullOrWhiteSpace(newTimeSlot))
            {
                return Result.Failure("New time slot can not be empty");
            }
            TimeSlot = newTimeSlot.Trim();
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
