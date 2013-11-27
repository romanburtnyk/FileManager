using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace FileManager.Intf
{
    public interface IPluginViewController
    {
        void SetPluginControl(IPlugin plugin, UIElement element, ImageSource toolboxImageSource);
        void AddFloatingWindow(IPlugin plugin, UIElement content, string windowName);
        bool SetMenuCommand(MenuPath path, ICommand command);
    }
}
