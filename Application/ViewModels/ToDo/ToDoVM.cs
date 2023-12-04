using System.ComponentModel.DataAnnotations;
using ViewModels.Abstracts;
namespace Application.ViewModels.ToDo
{
    public class ToDoVM : IBaseVM
    {
        [Key]
        public int? Id { get; set; }
        [Required(ErrorMessage = "error the name is required")]
        public string? Nome { get; set; }
        public string? Progress { get; set; }
        public DateTime? ConclusaoEm { get; set; }
    }
}
