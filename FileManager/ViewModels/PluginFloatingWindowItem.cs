using System;
using System.Windows;

namespace FileManager.ui
{
    internal class PluginFloatingWindowItem:ViewModel
    {
        private readonly string m_WindowName;
        private readonly UIElement m_Element;
        private bool m_IsVisible;


        public PluginFloatingWindowItem(string windowName, UIElement element)
        {
            m_WindowName = windowName;
            m_Element = element;
            IsVisible = false;
        }

        public UIElement Element
        {
            get { return m_Element; }
        }

        public string WindowName
        {
            get { return m_WindowName; }
        }

        public bool IsVisible
        {
            get { return m_IsVisible; }
            set
            {
                if (m_IsVisible != value)
                {
                    m_IsVisible = value;   
                    OnPropertyChanged("IsVisible");
                }
            }
        }
    }
}