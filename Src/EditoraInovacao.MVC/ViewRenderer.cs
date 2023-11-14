using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using EditoraInovacao.MVC.Properties;

namespace EditoraInovacao.MVC;

/// <summary>
/// The view renderer helper class.
/// </summary>
public static class ViewRenderer
{
    /// <summary>
    /// Creates the controller.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="routeData">The route data.</param>
    /// <returns>T.</returns>
    /// <exception cref="InvalidOperationException">Can't create Controller Context if no active HttpContext instance is available</exception>
    public static T CreateController<T>(RouteData routeData = null)
        where T : Controller, new()
    {
        var controller = new T();
        if (HttpContext.Current == null)
        {
            throw new InvalidOperationException(
                "Can't create Controller Context if no active HttpContext instance is available"
            );
        }

        var wrapper = new HttpContextWrapper(HttpContext.Current);

        if (routeData == null)
        {
            routeData = new RouteData();
        }

        if (
            !routeData.Values.ContainsKey("controller")
            && !routeData.Values.ContainsKey("Controller")
        )
        {
            routeData
                .Values
                .Add("controller", controller.GetType().Name.ToLower().Replace("controller", ""));
        }

        controller.ControllerContext = new ControllerContext(wrapper, routeData, controller);
        return controller;
    }

    /// <summary>
    /// Renders the view.
    /// </summary>
    /// <param name="viewName">Name of the view.</param>
    /// <param name="model">The model.</param>
    /// <returns>System.String.</returns>
    public static string RenderView(string viewName, object model) =>
        CreateController<EmptyController>().RenderView(viewName, model);

    /// <summary>
    /// A Controller extension method that renders the razor view to string.
    /// </summary>
    /// <param name="controller">The controller to act on.</param>
    /// <param name="viewName">Name of the view.</param>
    /// <param name="model">The model.</param>
    /// <returns>.</returns>
    /// <exception cref="ArgumentNullException">controller</exception>
    /// <exception cref="ArgumentNullException">controller - Extension method called on a null controller</exception>
    public static string RenderView(this Controller controller, string viewName, object model)
    {
        if (controller == null)
        {
            throw new ArgumentNullException(nameof(controller), Resources.ViewRenderer_RenderView);
        }

        if (controller.ControllerContext == null)
        {
            return string.Empty;
        }

        controller.ViewData.Model = model;
        using var sw = new StringWriter();
        var viewResult = ViewEngines
            .Engines
            .FindPartialView(controller.ControllerContext, viewName);
        var viewContext = new ViewContext(
            controller.ControllerContext,
            viewResult.View,
            controller.ViewData,
            controller.TempData,
            sw
        );
        viewResult.View.Render(viewContext, sw);
        viewResult.ViewEngine.ReleaseView(controller.ControllerContext, viewResult.View);
        return sw.GetStringBuilder().ToString();
    }
}
