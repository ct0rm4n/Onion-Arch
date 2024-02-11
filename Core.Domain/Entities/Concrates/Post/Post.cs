using Domain.Entities.Abstarct;

namespace Core.Domain.Entities.Concrates.Catalog
{
    public class Post : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public string Html { get; set; }
        public string Tags { get; set; }
        public int AppUserId { get; set; }
        public bool Publish { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}