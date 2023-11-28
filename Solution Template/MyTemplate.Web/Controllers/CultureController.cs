using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace MyTemplate.Web.Controllers;

[Route("[controller]/[action]")]
public class CultureController : Controller
{
    public IActionResult SetCulture(string culture, string redirectUri)
    {
        HttpContext.Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(
                new RequestCulture(culture)));

        return LocalRedirect(redirectUri);
    }
}