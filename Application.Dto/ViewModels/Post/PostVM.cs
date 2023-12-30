using ViewModels.Abstracts;
namespace Application.ViewModels.Post
{
    public class PostVM : IBaseVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Html { get; set; }
        public string Tags { get; set; }
        public int AppUserId { get; set; }
        public int Deleted { get; set; }
        public int Publish { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
