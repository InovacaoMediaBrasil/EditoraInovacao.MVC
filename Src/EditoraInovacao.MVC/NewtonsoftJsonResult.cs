using System;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace EditoraInovacao.MVC;

/// <summary>
/// The Newtonsoft Json result class.
/// </summary>
/// <seealso cref="JsonResult" />
public class NewtonsoftJsonResult : JsonResult
{
    #region Private fields

    /// <summary>
    /// The settings
    /// </summary>
    private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
    {
        Formatting = Formatting.Indented,
        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
    };

    #endregion

    #region Overrides of JsonResult

    /// <summary>
    /// Enables processing of the result of an action method by a custom type that inherits from the <see cref="System.Web.Mvc.ActionResult" /> class.
    /// </summary>
    /// <param name="context">The context within which the result is executed.</param>
    /// <exception cref="InvalidOperationException">GET request not allowed</exception>
    public override void ExecuteResult(ControllerContext context)
    {
        if (
            JsonRequestBehavior == JsonRequestBehavior.DenyGet
            && string.Equals(
                context.HttpContext.Request.HttpMethod,
                "GET",
                StringComparison.OrdinalIgnoreCase
            )
        )
        {
            throw new InvalidOperationException("GET request not allowed");
        }

        var response = context.HttpContext.Response;
        response.ContentType = !string.IsNullOrEmpty(ContentType)
            ? ContentType
            : "application/json";
        if (ContentEncoding != null)
        {
            response.ContentEncoding = ContentEncoding;
        }

        if (Data == null)
        {
            return;
        }

        response.Write(JsonConvert.SerializeObject(Data, Settings));
    }

    #endregion
}
