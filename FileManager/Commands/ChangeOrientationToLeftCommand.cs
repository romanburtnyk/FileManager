using System.ComponentModel.Composition;
using FileManager.ui.Interfaces;
using WpfUtils;

namespace FileManager.ui.Commands
{
    [CommandExport("ChangeOrientationToLeftCommand")]
    public class ChangeOrientationToLeftCommand : CommandBase
    {
        private readonly IPanelViewController m_PanelViewController;

        [ImportingConstructor]
        public ChangeOrientationToLeftCommand(IPanelViewController panelViewController)
        {
            m_PanelViewController = panelViewController;
        }

        protected override bool CanExecuteImpl(object parameter)
        {
            bool result = false;
            var viewHolder = parameter as PluginViewHolder;
            if (viewHolder != null)
            {
                result = viewHolder.IsVisible;
            }
            return result;
        }

        protected override void ExecuteImpl(object parameter)
        {
            var viewHolder = parameter as PluginViewHolder;
            if (viewHolder != null)
            {
                m_PanelViewController.SetLeftPluginOrientation(viewHolder);
            }
        }
    }
}
