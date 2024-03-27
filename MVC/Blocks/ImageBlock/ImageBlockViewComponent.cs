using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Web.Common;

namespace Rama.MVC.Blocks.ImageBlock
{
    [ViewComponent(Name = "imageBlock")]
    public class ImageBlockViewComponent : ViewComponent
    {
        private readonly IUmbracoHelperAccessor _umbracoHelperAccessor;


        public ImageBlockViewComponent(IUmbracoHelperAccessor umbracoHelperAccessor)
        {
            _umbracoHelperAccessor = umbracoHelperAccessor;
        }

        public async Task<IViewComponentResult> InvokeAsync(BlockListItem model)
        {
            var content = model.Content;

            if (content.GetType().FullName == "Umbraco.Cms.Web.Common.PublishedModels.ImageBlock")
            {
                // Use reflection to get property values
                var titleProperty = content.GetType().GetProperty("Title");
                var subtitleProperty = content.GetType().GetProperty("Subtitle");

                // Check if properties are not null
                if (titleProperty != null && subtitleProperty != null)
                {
                    // Get property values
                    var title = titleProperty.GetValue(content)?.ToString();
                    var subtitle = subtitleProperty.GetValue(content)?.ToString();

                    // Create ImageBlockViewModel
                    var myModel = new ImageBlockViewModel
                    {
                        Title = title,
                        Subtitle = subtitle,
                    };

                    return View("/Views/Partials/Blocks/ImageBlock.cshtml", myModel);
                }
            }

            return Content("Error: Invalid content type");
        }
    }
}
