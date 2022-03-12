namespace FishingBlog.Models.Publications
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AllPublicationsQueryModel
    {
        [Display(Name = "Search")]
        public string SearchTerm { get; init; }

        public IEnumerable<PublicationListingViewModel> Publications { get; init; }
    }
}
