using ViewModels.Abstracts;

namespace Application.Dto.ViewModels.Banner
{
    public class BannerSaveVM : SaveVM
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Binary { get; set; }
        public string Url { get; set; }
        public bool Publish { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
