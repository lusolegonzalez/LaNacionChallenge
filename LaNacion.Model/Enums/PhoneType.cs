using System.ComponentModel.DataAnnotations;

namespace LaNacion.Model.Enums
{
    public enum PhoneType
    {
        [Display(Name = "Mobile")]
        Mobile,
        [Display(Name = "Work")]
        Work,
        [Display(Name = "Home")]
        Home,
        [Display(Name = "Other")]
        Other
    }
}