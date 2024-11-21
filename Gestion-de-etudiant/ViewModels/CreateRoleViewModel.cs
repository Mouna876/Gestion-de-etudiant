using System.ComponentModel.DataAnnotations;

namespace Gestion_de_etudiant.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Role")]

        public string RoleName { get; set; }

    }
}
