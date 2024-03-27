using Umbraco.Cms.Core.Models.PublishedContent;

namespace Rama.MVC.Pages.AboutUs
{
    public class AboutUsViewModel : PublishedContentWrapped
    {
        public AboutUsViewModel(IPublishedContent content, IPublishedValueFallback publishedValueFallback) : base(content, publishedValueFallback)
        {

        }

        public string Title { get; set; }
        public string Description { get; set; }
    }
}
