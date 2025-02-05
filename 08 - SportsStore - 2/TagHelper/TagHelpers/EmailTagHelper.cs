using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ContactManager.TagHelpers;

public class EmailTagHelper : TagHelper
{
    private const string EmailDomain = "mymail.com";
    public required string MailTo { get; set; }

    // Sobreescribiento el método Process de la clase TagHelper.
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        // Construyendo la dirección de correo electrónico.
        var address = MailTo + "@" + EmailDomain;

        // El tag es un enlace <a>...
        output.TagName = "a";
        // ...con el atributo href...
        output.Attributes.SetAttribute("href", "mailto:" + address);
        // ...que contiene la dirección de correo electrónico.
        output.Content.SetContent(address);
    }
}
