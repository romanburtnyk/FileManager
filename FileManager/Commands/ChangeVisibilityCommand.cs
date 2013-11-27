using System;
using System.ComponentModel.Composition;
using FileManager.Intf.Annotations;
using FileManager.ui.Interfaces;
using WpfUtils;

namespace FileManager.ui.Commands
{
    [CommandExport("ChangeVisibilityCommand")]
    public class ChangeVisibilityCommand : CommandBase
    {
         private readonly IPanelViewController m_PanelViewController;

        [ImportingConstructor]
         public ChangeVisibilityCommand([NotNull] IPanelViewController panelViewController)
        {
            if (panelViewController == null) throw new ArgumentNullException("panelViewController");
            m_PanelViewController = panelViewController;
        }

        protected override bool CanExecuteImpl(object parameter)
        {
            bool result = false;
            var viewHolder = parameter as PluginViewHolder;
            if (viewHolder != null)
            {
                result = viewHolder.IsVisible || m_PanelViewController.CanSetVisibility();
            }
            return result;
        }

        protected override void ExecuteImpl(object parameter)
        {
            var viewHolder = parameter as PluginViewHolder;
            if (viewHolder != null)
            {
                m_PanelViewController.SetPanelVisibility(viewHolder);
                viewHolder.IsVisible = !viewHolder.IsVisible;
            }
        }
    }
}