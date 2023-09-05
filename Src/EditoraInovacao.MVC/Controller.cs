// ***********************************************************************
// Assembly         : IntegracaoService.Commons.MVC
// Author           : Guilherme Branco Stracini
// Created          : 18/04/2020
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 17/01/2023
// ***********************************************************************
// <copyright file="Controller.cs" company="Guilherme Branco Stracini ME">
//     © 2012-2023 Guilherme Branco Stracini ME, All Rights Reserved
// </copyright>
// <summary></summary>
// ************************************************************************

using System.Linq;
using System.Text;
using System.Web.Mvc;
using CrispyWaffle.Utilities;

namespace EditoraInovacao.MVC;

/// <summary>
/// The abstract class controller with Json method overriden
/// </summary>
/// <seealso cref="System.Web.Mvc.Controller" />
public abstract class Controller : System.Web.Mvc.Controller
{
    #region Overrides of Controller

    /// <summary>
    /// Creates a <see cref="System.Web.Mvc.JsonResult" /> object that serializes the specified object to JavaScript Object Notation (JSON) format using the content type, content encoding, and the JSON request behavior.
    /// </summary>
    /// <param name="data">The JavaScript object graph to serialize.</param>
    /// <param name="contentType">The content type (MIME type).</param>
    /// <param name="contentEncoding">The content encoding.</param>
    /// <param name="behavior">The JSON request behavior</param>
    /// <returns>The result object that serializes the specified object to JSON format.</returns>
    protected override JsonResult Json(
        object data,
        string contentType,
        Encoding contentEncoding,
        JsonRequestBehavior behavior
    ) =>
        new NewtonsoftJsonResult
        {
            Data = data,
            ContentType = contentType,
            ContentEncoding = contentEncoding,
            JsonRequestBehavior = behavior
        };

    #endregion

    /// <summary>
    /// Errors the response.
    /// </summary>
    /// <param name="code">The code.</param>
    /// <param name="errorMessage">The error message.</param>
    /// <returns>JsonResult.</returns>
    public JsonResult ErrorResponse(int code, string errorMessage) =>
        Json(
            new ErrorResponse
            {
                Code = code,
                ErrorMessage = errorMessage,
                ErrorList = ModelState.IsValid
                    ? null
                    : ModelState
                        .Where(kvp => kvp.Value.Errors.Any())
                        .ToDictionary(
                            kvp => kvp.Key,
                            kvp => kvp.Value.Errors.Select(e => e.ErrorMessage)
                        )
            },
            JsonRequestBehavior.AllowGet
        );
}
