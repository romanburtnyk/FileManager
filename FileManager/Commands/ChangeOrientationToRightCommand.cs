using System.ComponentModel.Composition;
using FileManager.ui.Interfaces;
using WpfUtils;

namespace FileManager.ui.Commands
{
    [CommandExport("ChangeOrientationToRightCommand")]
    public class ChangeOrientationToRightCommand : CommandBase
    {
        private readonly IPanelViewController m_PanelViewController;

        [ImportingConstructor]
        public ChangeOrientationToRightCommand(IPanelViewController panelViewController)
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
                m_PanelViewController.SetRightPluginOrientation(viewHolder);
            }
        }
    }
}