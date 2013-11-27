using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using FileManager.Intf;

namespace FileManager.ui
{
    public class PluginViewHolder: ViewModel
    {
        private readonly UIElement m_PluginView;

        public UIElement View
        {
            get { return m_PluginView; }
        }

        public PluginViewHolder(ImageSource toolboxImageSource, UIElement pluginView, IPlugin plugin)
        {
            m_ToolboxImageSource = toolboxImageSource ??
                                   new BitmapImage(new Uri("pack://application:,,,/FileManager.ui;component/none.jpg"));

            m_PluginView = pluginView;
            IsVisible = false;
            m_Name = plugin.Name;
            m_Description = plugin.Description;
        }

        private string m_Description;
        public string Description
        {
            get { return m_Description; }
            set
            {
                if (m_Description != value)
                {
                    m_Description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        private string m_Name;
        public string Name
        {
            get { return m_Name; }
            set
            {
                if (m_Name != value)
                {
                    m_Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }


        public bool IsVisible { get; set; }


        private ImageSource m_ToolboxImageSource;
        public ImageSource ToolboxImageSource
        {
            get { return m_ToolboxImageSource; }
            set
            {
                if (m_ToolboxImageSource != value)
                {
                    m_ToolboxImageSource = value;
                    OnPropertyChanged("ToolboxImageSource");
                }
            }
        }
    }
}