using Domain.Enums;

namespace Domain.Entities.Abstarct
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            InsertedDate = DateTime.Now;
            Status = Status.Inserted;
        }
        public int Id { get; set; }
        public DateTime? InsertedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public Status Status { get; set; }

    }
}
