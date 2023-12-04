using ViewModels.Abstracts;

namespace Application
{
    public class ToDoSaveVM : SaveVM
    {
        public string? Nome { get; set; }
        public string? Status { get; set; }
        public DateTime ConclusaoEm { get; set; }
    }
}
