using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace Rama.MVC.Pages.AboutUs
{
    public class AboutUsController : RenderController
    {
        private readonly ServiceContext _serviceContext;
        private readonly IVariationContextAccessor _variationContextAccessor;
        public AboutUsController(
            ILogger<RenderController> logger,
            ICompositeViewEngine compositeViewEngine,
            IUmbracoContextAccessor umbracoContextAccessor,
            IVariationContextAccessor variationContextAccessor,
            ServiceContext serviceContext)
             : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            _serviceContext = serviceContext;
            _variationContextAccessor = variationContextAccessor;
        }

        public override IActionResult Index()
        {
            var aboutUsViewModel = new AboutUsViewModel(CurrentPage, new PublishedValueFallback(_serviceContext, _variationContextAccessor));

            aboutUsViewModel.Title = "Test Value";

            return CurrentTemplate(aboutUsViewModel);
        }
    }
}
