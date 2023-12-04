using System.ComponentModel.DataAnnotations;
using ViewModels.Abstracts;

namespace ViewModels.AppRole
{
    public class AppRoleVM : IBaseVM
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o nome")]
        [StringLength(80, ErrorMessage = "Nome muito longo.")]
        public string Name { get; set; }
        public bool isAssigned { get; set; } 
    }
}
