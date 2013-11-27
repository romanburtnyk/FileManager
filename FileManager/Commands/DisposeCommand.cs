using System;
using System.ComponentModel.Composition;
using FileManager.Intf.Annotations;
using FileManager.ui.Interfaces;
using WpfUtils;

namespace FileManager.ui.Commands
{
    [CommandExport("DisposeCommand")]
    public class DisposeCommand : CommandBase
    {
        private readonly IPluginDisposable m_Disposer;
        [ImportingConstructor]
        public DisposeCommand([NotNull] IPluginDisposable disposer)
        {
            if (disposer == null) throw new ArgumentNullException("disposer");
            m_Disposer = disposer;
        }

        protected override bool CanExecuteImpl(object parameter)
        {
            return true;
        }

        protected override void ExecuteImpl(object parameter)
        {
            m_Disposer.PluginDispose();
        }
    }
}