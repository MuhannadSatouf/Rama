using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace Rama.MVC.Pages.ExampleReactPage
{
    public class ExampleReactPageController : RenderController
    {
        private readonly ServiceContext _serviceContext;
        private readonly IVariationContextAccessor _variationContextAccessor;
        public ExampleReactPageController(
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

            var exampleReactPageViewModel = new ExampleReactPageViewModel(CurrentPage, new PublishedValueFallback(_serviceContext, _variationContextAccessor));

            return CurrentTemplate(exampleReactPageViewModel);
        }
    }
}
