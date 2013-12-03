using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using FileManager.Intf;
using FileManager.ui.Interfaces;
using Version = FileManager.Intf.Version;

namespace FileManager.ui
{
    [Export(typeof(IPluginViewController))]
    [Export(typeof(IPanelViewController))]
    [Export(typeof(IPluginDisposable))]
    [Export(typeof(MainViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    internal class MainViewModel : ViewModel, IPluginViewController, IPluginDisposable, IPanelViewController
    {
        [ImportMany]
        public List<Lazy<IPlugin>> LazyPlugins { get; set; }

        private List<IPlugin> m_Plugins;

        private readonly Version m_Version = new Version(1, 0);

        public void Initialize()
        {
            m_Plugins = LazyPlugins.Select(lazy => lazy.Value).ToList();
            m_Plugins = PluginLoadingHelper.GetValidPlugins(m_Plugins, m_Version);
            foreach (var plugin in m_Plugins)
            {
                try
                {
                    plugin.ApplyPlugin();
                }
                catch (Exception ex)
                {
                    LogManager.Error(String.Format("Plugin raise an exception:{0}, Plugin: {1}", ex.Message, PluginLoadingHelper.PluginTostring(plugin) ));
                }
            }
        }

        #region IPluginDisposable impl

        public void PluginDispose()
        {
            foreach (var plugin in m_Plugins)
            {
                try
                {
                    plugin.Dispose();
                }
                catch (Exception ex)
                {
                    LogManager.Error(ex.Message + "  " + PluginLoadingHelper.PluginTostring(plugin));
                }
            }
        }

        #endregion


        #region IPluginViewController impl

        public void SetPluginControl(IPlugin plugin, UIElement element, ImageSource toolboxImageSource)
        {
            if (m_PluginViewHolders.ContainsKey(plugin))
            {
                m_PluginViewHolders[plugin] = new PluginViewHolder(toolboxImageSource, element, plugin);
            }
            else
            {
                m_PluginViewHolders.Add(plugin, new PluginViewHolder(toolboxImageSource, element, plugin));
            }
            OnPropertyChanged("PluginViewHolders");
        }

        public void AddFloatingWindow(IPlugin plugin, UIElement content, string windowName)
        {
            var floatingWindowItem = new PluginFloatingWindowItem(windowName, content);
            m_PluginFloatingWindows.Add(floatingWindowItem);
        }

        public bool SetMenuCommand(MenuPath path, ICommand command)
        {
            return false;
        }

        #endregion

        #region IPanelViewController impl

        public void SetLeftPluginOrientation(PluginViewHolder pluginView)
        {
            if (LeftContent != pluginView.View)
            {
                RightContent = LeftContent;
                LeftContent = pluginView.View;
            }
        }

        public void SetRightPluginOrientation(PluginViewHolder pluginView)
        {
            if (RightContent != pluginView.View)
            {
                LeftContent = RightContent;
                RightContent = pluginView.View;
            }
        }

        public void SetPanelVisibility(PluginViewHolder pluginView)
        {
            if (pluginView.IsVisible)
            {
                if (LeftContent == pluginView.View)
                {
                    LeftContent = null;
                }
                else
                {
                    RightContent = null;
                }
            }
            else
            {
                if (LeftContent == null)
                {
                    LeftContent = pluginView.View;
                }
                else
                {
                    RightContent = pluginView.View;
                }
            }
        }

        public bool CanSetVisibility()
        {
            return LeftContent == null || RightContent == null;
        }

        #endregion


        #region LeftContent property

        private UIElement m_LeftContent;

        public UIElement LeftContent
        {
            get { return m_LeftContent; }
            set
            {
                if (m_LeftContent != value)
                {
                    m_LeftContent = value;
                    OnPropertyChanged("LeftContent");
                }
            }
        }

        #endregion

        #region RightContent property
        private UIElement m_RightContent;
        
        public UIElement RightContent
        {
            get { return m_RightContent; }
            set
            {
                if (m_RightContent != value)
                {
                    m_RightContent = value;
                    OnPropertyChanged("RightContent");
                }
            }
        }

        #endregion

        #region PluginViewHolders property
        private readonly Dictionary<IPlugin, PluginViewHolder> m_PluginViewHolders = new Dictionary<IPlugin, PluginViewHolder>();

        public Dictionary<IPlugin, PluginViewHolder> PluginViewHolders
        {
            get { return m_PluginViewHolders; }
        }
        #endregion






        #region PluginFloatingWindows property

        private readonly ObservableCollection<PluginFloatingWindowItem> m_PluginFloatingWindows = new ObservableCollection<PluginFloatingWindowItem>();
        public ObservableCollection<PluginFloatingWindowItem> PluginFloatingWindows
        {
            get { return m_PluginFloatingWindows; }
        }

        #endregion

    }
}