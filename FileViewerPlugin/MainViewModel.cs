using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FileManager.Intf;

namespace FileViewerPlugin
{
    class MainViewModel:ViewModel
    {
        private ObservableCollection<FileInfoViewModel> m_FileInfos = new ObservableCollection<FileInfoViewModel>();


        public ObservableCollection<FileInfoViewModel> FileInfos
        {
            get { return m_FileInfos; }
            set
            {
                if (Equals(value, m_FileInfos)) return;
                m_FileInfos = value;
                OnPropertyChanged();
            }
        }



        public MainViewModel(IPluginContext context)
        {
            m_FileInfos = new ObservableCollection<FileInfoViewModel>(context.FileList.Select(info => new FileInfoViewModel(info)));
        }
    }
}