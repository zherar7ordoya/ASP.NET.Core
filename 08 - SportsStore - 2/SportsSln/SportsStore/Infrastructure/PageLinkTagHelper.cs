using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SportsStore.Models.ViewModels;


namespace SportsStore.Infrastructure;


// *****************************************************************************
// Esta clase, PageLinkTagHelper, es un Tag Helper personalizado. Su propósito es
// generar enlaces de paginación dinámicos dentro de un <div>, creando una serie
// de <a> con los números de página correspondientes. Se usa en una vista Razor
// para construir una barra de paginación sin necesidad de escribir el código
// manualmente en cada vista.
// *****************************************************************************

// Atributos de Tag Helpers: Le dice a ASP.NET que esta clase solo se aplicará a
// elementos <div> que tengan el atributo page-model.
[HtmlTargetElement("div", Attributes = "page-model")]
// Inyección de dependencias con el constructor primario:
//  * IUrlHelperFactory se recibe en el constructor y se almacena en urlHelperFactory.
//  * Esto se usa para generar URLs dinámicas dentro de la vista.
public class PageLinkTagHelper(IUrlHelperFactory helperFactory) : TagHelper
{
    private readonly IUrlHelperFactory urlHelperFactory = helperFactory;

    [ViewContext]
    [HtmlAttributeNotBound]
    public ViewContext? ViewContext { get; set; }
    public PagingInfo? PageModel { get; set; }
    public string? PageAction { get; set; }

    [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
    public Dictionary<string, object> PageUrlValues { get; set; } = [];

    public bool PageClassesEnabled { get; set; } = false;
    public string PageClass { get; set; } = string.Empty;
    public string PageClassNormal { get; set; } = string.Empty;
    public string PageClassSelected { get; set; } = string.Empty;

    // En Process, se genera un <div> que contiene varios <a>, uno por cada página.
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (ViewContext != null && PageModel != null)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder result = new("div");

            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder tag = new("a");

                PageUrlValues["productPage"] = i;

                // Se usa IUrlHelper.Action(PageAction, PageUrlValues) para
                // construir dinámicamente los href.
                tag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);

                // Si PageClassesEnabled es true, se agregan clases CSS dinámicas
                // para resaltar la página seleccionada.
                if (PageClassesEnabled)
                {
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass(i == PageModel.CurrentPage
                                         ? PageClassSelected
                                         : PageClassNormal);
                }

                tag.InnerHtml.Append(i.ToString());
                result.InnerHtml.AppendHtml(tag);
            }

            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
