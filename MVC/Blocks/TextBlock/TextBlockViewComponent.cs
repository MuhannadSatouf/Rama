using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common;
using Umbraco.Cms.Core.Models.Blocks;

namespace Rama.MVC.Blocks.TextBlock
{
    //SHould have the decoration and name as Viewcomponent to make it work.

    [ViewComponent(Name = "textBlock")]
    public class TextBlockViewComponent : ViewComponent
    {
        private readonly IUmbracoHelperAccessor _umbracoHelperAccessor;


        public TextBlockViewComponent(IUmbracoHelperAccessor umbracoHelperAccessor)
        {
            _umbracoHelperAccessor = umbracoHelperAccessor;
        }

        public async Task<IViewComponentResult> InvokeAsync(BlockListItem model)
        {
            var content = model.Content;

            if (content.GetType().FullName == "Umbraco.Cms.Web.Common.PublishedModels.TextBlock")
            {
                // Use reflection to get property values
                var titleProperty = content.GetType().GetProperty("Title");
                var subtitleProperty = content.GetType().GetProperty("Subtitle");
                var bodyTextProperty = content.GetType().GetProperty("BodyText");

                // Check if properties are not null
                if (titleProperty != null && subtitleProperty != null && bodyTextProperty != null)
                {
                    // Get property values
                    var title = titleProperty.GetValue(content)?.ToString();
                    var subtitle = subtitleProperty.GetValue(content)?.ToString();
                    var bodyText = bodyTextProperty.GetValue(content)?.ToString();

                    // Create TextBlockViewModel
                    var myModel = new TextBlockViewModel
                    {
                        Title = title,
                        Subtitle = subtitle,
                        BodyText = bodyText
                    };

                    return View("/Views/Partials/Blocks/TextBlock.cshtml", myModel);
                }
            }

            return Content("Error: Invalid content type");
        }

    }
}
