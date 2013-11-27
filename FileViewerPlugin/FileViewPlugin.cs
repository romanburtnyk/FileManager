using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using FileManager.Intf;
using Version = FileManager.Intf.Version;

namespace FileViewerPlugin
{
    [Export(typeof(IPlugin))]
    public class FileViewPlugin:IPlugin
    {
        private readonly IPluginContext m_Context;
        private readonly IPluginViewController m_Controller;
        private readonly IContextPubliser m_Publisher;

        [ImportingConstructor]
        public FileViewPlugin(IPluginContext context, IPluginViewController controller, IContextPubliser publisher)
        {
            m_Context = context;
            m_Controller = controller;
            m_Publisher = publisher;
        }

        public void Dispose()
        {
            
        }

        public Version SupportedManagerVersion { get{return new Version(1, 0);} }
        public Version Version { get { return new Version(1, 0); } }
        public string Name { get { return "FileViewer"; } }
        public string Uid { get { return "2c6d0a70-538b-11e3-8f96-0800200c9a66"; } }
        public string Description { get { return "File browser"; } }
        public void ApplyPlugin()
        {
            m_Controller.SetPluginControl(this, new FileViewControl(), null);
        }
    }
}
