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
        public TimeOnly StartTime{ get; private set; } 
        public TimeOnly EndTime { get; private set; }
        public bool isDeleted { get; private set; }
        protected Schedule() { }
        private Schedule(int classSubjectId, int teacherId, int? roomId, DayOfWeek day, TimeOnly startTime, TimeOnly endTime)
        {
            ClassSubjectId = classSubjectId;
            TeacherId = teacherId;
            RoomId = roomId;
            Day = day;
            StartTime = startTime;
            EndTime = endTime;
        }
        public static ResultGeneric<Schedule> Create(int classSubjectId, int teacherId, int? roomId, DayOfWeek day, TimeOnly startTime, TimeOnly endTime)
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

            if (endTime <= startTime)
            {
                return ResultGeneric<Schedule>.Failure("End time can not be lesser than startTime");
            }

            var schedule = new Schedule(classSubjectId, teacherId, roomId, day, startTime, endTime);
            return ResultGeneric<Schedule>.Success(schedule);
        }
        public Result UpdateTime(TimeOnly startTime, TimeOnly endTime)
        {

            StartTime = startTime;
            EndTime = endTime;
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
