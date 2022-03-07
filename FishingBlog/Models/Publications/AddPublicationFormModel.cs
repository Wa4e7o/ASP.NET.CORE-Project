namespace FishingBlog.Models.Publications
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class AddPublicationFormModel
    {
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = "Title must be between 5 and 200 characters long.")]
        public string Title { get; init; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = "The description text must be between 10 and 5000 characters long.")]
        public string Description { get; init; }

        [Required]
        [Url]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; }

        [Display(Name = "Post Date:")]
        public string PublishedOn { get; init; }

        [Display(Name = "Sections")]
        public int TopicId { get; init; }

        public IEnumerable<TopicCategoryViewModel> Sections { get; set; }
    }
}
