using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using FileManager.Intf;
using FileManager.Intf.Annotations;
using Version = FileManager.Intf.Version;

namespace PluginTestApp
{
    [Export(typeof(IPlugin)) ]
    class SomePlugin:IPlugin
    {
        private readonly IPluginContext m_Context;
        private readonly IPluginViewController m_Menu;

        [ImportingConstructor]
        public SomePlugin([NotNull] IPluginContext context, [NotNull] IPluginViewController menu
)
        {
            if (context == null) 
                throw new ArgumentNullException("context");
            if (menu == null) 
                throw new ArgumentNullException("menu");
            m_Context = context;
            m_Menu = menu;
        }

        public Version SupportedManagerVersion
        {
            get
            {
                return new Version(1, 0);
            }
        }

        public Version Version
        {
            get
            {
                return new Version(1, 0);
            }
        }

        public string Name
        {
            get
            {
                return "Test";
            }
        }
        
        public string Uid
        {
            get
            {
                return "807363b0-4dfc-11e3-8f96-0800200c9a66";
            }
        }

        public string Description
        {
            get
            {
                return "Test plugin";
            }
        }

        public void ApplyPlugin()
        {
            m_Menu.SetPluginControl(this, new UserControl1(), null);
            m_Menu.AddFloatingWindow(this, new UserControl1(), Name);
        }

        public void Dispose()
        {
        }
    }
}
