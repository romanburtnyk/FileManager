using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using FileManager.Intf;
using FileManager.Intf.Annotations;

namespace FileManager.ui
{
    [PartCreationPolicy(CreationPolicy.Shared)]
    [Export(typeof(IPluginContext))]
    internal class PluginContext : IPluginContext
    {
        private List<FileSystemInfo> m_FileList;
        private DirectoryInfo m_Current;
        private List<FileInfo> m_SelectedFiles;

        public PluginContext()
        {
            Current = new DirectoryInfo(".");
            FileList = Current.GetFileSystemInfos().ToList();
        }

        public DirectoryInfo Current
        {
            get { return m_Current; }
            set
            {
                if (Equals(value, m_Current)) return;
                m_Current = value;
                OnPropertyChanged();
            }
        }

        public List<FileSystemInfo> FileList
        {
            get { return m_FileList; }
            set
            {
                if (Equals(value, m_FileList)) return;
                m_FileList = value;
                OnPropertyChanged();
            }
        }

        public List<FileInfo> SelectedFiles
        {
            get { return m_SelectedFiles; }
            set
            {
                if (Equals(value, m_SelectedFiles)) return;
                m_SelectedFiles = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}