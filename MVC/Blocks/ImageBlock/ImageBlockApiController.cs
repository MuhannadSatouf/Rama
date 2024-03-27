using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.Entities;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Common;
using Umbraco.Cms.Web.Common.UmbracoContext;
using Umbraco.Cms.Web.Website.Controllers;

namespace Rama.MVC.Blocks.ImageBlock
{
    [Route("api/imageBlock")]
    public class ImageBlockApiController : SurfaceController
    {
        private readonly IPublishedContentQuery _publishedContentQuery;
        private readonly IContentService _contentService;
        private readonly IContentTypeService _contentTypeService;
        public ImageBlockApiController(
          IUmbracoContextAccessor umbracoContextAccessor,
          IUmbracoDatabaseFactory databaseFactory,
          ServiceContext services,
          AppCaches appCaches,
          IProfilingLogger profilingLogger,
          IPublishedUrlProvider publishedUrlProvider,
          IContentService contentService,
          IPublishedContentQuery publishedContentQuery,
          IContentTypeService contentTypeService
         )
          : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            _contentService = contentService;
            _publishedContentQuery = publishedContentQuery;
            _contentTypeService = contentTypeService;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetImageBlock(string id)
        {
            Guid blockId = RemoveDashesAndConvertToGuid(id);

            Udi umbId = Udi.Create("element", blockId);
            //var whatever = _umbracoHelper.ContentAtRoot();
            //var test10 = _contentTypeService.
            //var t = _contentService.GetById(blockId);
            //var block = _publishedContentQuery.Content(umbId);
            //var blocke = _umbracoHelper.Content(umbId);
            //var contentHelkpper = _umbracoHelper.Content(umbId);

            var item = 0;



            return Ok(id);
        }

        public Guid RemoveDashesAndConvertToGuid(string id)
        {
            string strippedId = id.Replace("-", "");
            return Guid.Parse(strippedId);
        }
    }
}
