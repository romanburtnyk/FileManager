using System.ComponentModel.Composition;
using FileManager.Intf;
using WpfUtils;

namespace FileManager.ui.Composition
{
    [Export(typeof(IContextPubliser))]
    class ContextPublisher:IContextPubliser
    {
        public void PublishContext<T>(T context)
        {
            CompositionService.ComposeExportedValue(context);
        }


        public T GetContext<T>()
        {
            return CompositionService.GetExportedValue<T>();
        }
    }
}
