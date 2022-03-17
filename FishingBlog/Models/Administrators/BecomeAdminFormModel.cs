namespace FishingBlog.Models.Administrators
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.Administrator;

    public class BecomeAdminFormModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        [Display(Name = "User")]
        public string UserName { get; set; }
    }
}
