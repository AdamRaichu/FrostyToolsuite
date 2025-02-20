using FrostySdk.Ebx;
using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace Frosty.Core.Attributes
{
    /// <summary>
    /// This attribute registers a data explorer context menu item to the plugin system.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true, Inherited = true)]
    public class RegisterBlueprintEditorHandlerAttribute : Attribute
    {
        public Type classToHandle { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterBlueprintEditorHandlerAttribute"/> class using the tab extension type.
        /// </summary>
        /// <param name="type">The type of the menu extension. This type must derive from <see cref="ContextMenu"/></param>
        public RegisterBlueprintEditorHandlerAttribute(Type type)
        {
            classToHandle = type;
        }
    }

    public interface IBlueprintEditorHandler
    {
        void OpenPointerRefAsGraph(PointerRef ptr, ComboBox popup);
    }
}
