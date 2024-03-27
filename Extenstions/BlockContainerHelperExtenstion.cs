using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.Blocks;

namespace Rama.Extenstions
{
    public static class BlockContainerHelperExtenstion
    {

        public static async Task<IHtmlContent> BlockContainerAsync(this IViewComponentHelper component, BlockListModel containers, string containerId)
        {
            var builder = new HtmlContentBuilder();
            if (containers == null || containers.Count == 0)
            {
                return builder;
            }

            foreach (var blockModel in containers)
            {
                if (blockModel.Content != null)
                {
                    var key = blockModel.Content.Key;
                    var controllerType = blockModel.Content.ContentType.Alias.ToString();
                    var tagBuilder = new TagBuilder("section");
                    tagBuilder.Attributes["data-block-id"] = key.ToString();
                    if (!string.IsNullOrEmpty(controllerType))
                    {
                        tagBuilder.InnerHtml.AppendHtml(await component.InvokeAsync(controllerType, blockModel));
                        builder.AppendHtml(tagBuilder);
                        builder.AppendLine();
                    }
                }
            }
            return builder;
        }
    }
}
