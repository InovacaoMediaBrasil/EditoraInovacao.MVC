using System.Web.Mvc;

namespace EditoraInovacao.MVC;

/// <summary>
/// Class ExtendedSelectListItem.
/// </summary>
/// <seealso cref="SelectListItem" />
public class ExtendedSelectListItem : SelectListItem
{
    /// <summary>
    /// Gets or sets the HTML attributes.
    /// </summary>
    /// <value>The HTML attributes.</value>
    public object HtmlAttributes { get; set; }
}
