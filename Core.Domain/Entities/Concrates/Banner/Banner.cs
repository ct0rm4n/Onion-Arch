using Domain.Entities.Abstarct;

namespace Core.Domain.Entities.Concrates.Catalog
{
    public class Banner : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Binary { get; set; }
        public bool Publish { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}