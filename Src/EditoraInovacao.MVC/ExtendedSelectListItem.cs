// ***********************************************************************
// Assembly         : IntegracaoService.Commons.MVC
// Author           : Guilherme Branco Stracini
// Created          : 18/04/2020
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 17/01/2023
// ***********************************************************************
// <copyright file="ExtendedSelectListItem.cs" company="Guilherme Branco Stracini ME">
//     © 2012-2023 Guilherme Branco Stracini ME, All Rights Reserved
// </copyright>
// <summary></summary>
// ***********************************************************************

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
