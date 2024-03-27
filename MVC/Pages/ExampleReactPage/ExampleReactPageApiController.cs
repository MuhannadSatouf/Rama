using Umbraco.Cms.Core;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.PublishedContent;
using Rama.MVC.Services;

namespace Rama.MVC.Pages.ExampleReactPage
{
    [Route("api/exampleReactPage")]
    public class ExampleReactPageApiController : ControllerBase
    {
        private readonly IPublishedContentQuery _publishedContentQuery;
        private readonly IPublishedValueFallback _publishedValueFallback;

        public ExampleReactPageApiController(IPublishedContentQuery publishedContentQuery, IPublishedValueFallback publishedValueFallback)
        {
            _publishedContentQuery = publishedContentQuery;
            _publishedValueFallback = publishedValueFallback;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetPage(int id)
        {
            var content = _publishedContentQuery.Content(id);
            if (content == null)
            {
                return NotFound();
            }

            var exampleReactPageViewModel = new ExampleReactPageViewModel(content, _publishedValueFallback);

            // Using the CustomHtmlhelper class to strip HTML tags from the page body that has filed type "Richtext editor"
            string strippedPageBody = CustomHtmlhelper.StripHtmlTags(exampleReactPageViewModel.PageBody);

            var modelData = new
            {
                PageTitle = exampleReactPageViewModel.PageTitle,
                PageBody = strippedPageBody
            };

            return Ok(modelData);
        }
    }
}
