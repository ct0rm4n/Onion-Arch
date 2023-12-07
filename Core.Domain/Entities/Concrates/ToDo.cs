using Domain.Entities.Abstarct;

namespace Domain.Entities.Concrates
{
    public  class ToDo : BaseEntity, IEntity
    {
        public string? Nome { get; set; }
        public string? Description { get; set; }
        public string? Progress { get; set; }
        public DateTime? ConclusaoEm { get; set; }
    }
}
