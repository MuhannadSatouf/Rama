using Umbraco.Cms.Core.Models.PublishedContent;

namespace Rama.MVC.Pages.ExampleReactPage
{
    public class ExampleReactPageViewModel : PublishedContentModel
    {

        private readonly IPublishedContent _content;
        private IPublishedValueFallback _publishedValueFallback;

        public ExampleReactPageViewModel(IPublishedContent content, IPublishedValueFallback publishedValueFallback) : base(content, publishedValueFallback)
        {
            _publishedValueFallback = publishedValueFallback;
            _content = content;
        }

        public string PageTitle => _content.Value<string>("PageTitle");
        public string PageBody => _content.Value<string>("PageBody");
    }
}
