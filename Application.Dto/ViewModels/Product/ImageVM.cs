using ViewModels.Abstracts;

namespace ViewModels.Product
{
    public class ImageVM : IBaseVM
    {
        public int Id { get; set; }
        public string Binary { get; set; } = string.Empty;
    }
}