using System;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;

namespace EditoraInovacao.MVC;

/// <summary>
/// The enum flags model binder class.
/// </summary>
/// <seealso cref="DefaultModelBinder" />
public sealed class EnumFlagsModelBinder : DefaultModelBinder
{
    #region Overrides of DefaultModelBinder

    /// <summary>
    /// Returns the value of a property using the specified controller context, binding context, property descriptor, and property binder.
    /// </summary>
    /// <param name="controllerContext">The context within which the controller operates. The context information includes the controller, HTTP content, request context, and route data.</param>
    /// <param name="bindingContext">The context within which the model is bound. The context includes information such as the model object, model name, model type, property filter, and value provider.</param>
    /// <param name="propertyDescriptor">The descriptor for the property to access. The descriptor provides information such as the component type, property type, and property value. It also provides methods to get or set the property value.</param>
    /// <param name="propertyBinder">An object that provides a way to bind the property.</param>
    /// <returns>An object that represents the property value.</returns>
    protected override object GetPropertyValue(
        ControllerContext controllerContext,
        ModelBindingContext bindingContext,
        PropertyDescriptor propertyDescriptor,
        IModelBinder propertyBinder
    )
    {
        var propertyType = propertyDescriptor.PropertyType;

        if (
            !propertyType.IsEnum
            || !propertyType.GetCustomAttributes(typeof(FlagsAttribute), false).Any()
        )
        {
            return base.GetPropertyValue(
                controllerContext,
                bindingContext,
                propertyDescriptor,
                propertyBinder
            );
        }

        var providerValue = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
        var value = providerValue?.RawValue;
        if (value == null)
        {
            return base.GetPropertyValue(
                controllerContext,
                bindingContext,
                propertyDescriptor,
                propertyBinder
            );
        }

        if (value is not string[] strings)
        {
            return value.GetType().IsEnum
                ? Enum.ToObject(propertyType, value)
                : base.GetPropertyValue(
                    controllerContext,
                    bindingContext,
                    propertyDescriptor,
                    propertyBinder
                );
        }

        var flagValue = strings.Aggregate(0, (acc, i) => acc | (int)Enum.Parse(propertyType, i));
        return Enum.ToObject(propertyType, flagValue);
    }

    #endregion
}
