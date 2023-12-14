
using ViewModels.Abstracts;

namespace Service.Interface.ViewModels.Product
{
    public class ProductTypeSaveVM : SaveVM, IBaseVM
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public bool Editing { get; set; } = false;
        public bool IsNew { get; set; } = false;
    }
}
