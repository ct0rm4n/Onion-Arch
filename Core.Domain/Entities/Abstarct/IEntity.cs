using Domain.Enums;

namespace Domain.Entities.Abstarct
{
    public interface IEntity
    {
        public DateTime? InsertedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public Status Status { get; set; }
    }
}
