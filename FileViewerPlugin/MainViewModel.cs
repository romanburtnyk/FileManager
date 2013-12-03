using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace FileViewerPlugin
{
    class MainViewModel:ViewModel
    {
        private ObservableCollection<IFileInfoViewModel> m_FileInfos = new ObservableCollection<IFileInfoViewModel>();
        private string m_CurrentDir;

        public ObservableCollection<IFileInfoViewModel> FileInfos
        {
            get { return m_FileInfos; }
            set
            {
                if (Equals(value, m_FileInfos)) return;
                m_FileInfos = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            ChangeDirectory(".");
        }

        private void ChangeDirectory(string newDirectory)
        {
            if (newDirectory != m_CurrentDir)
            {
                var collection = 
                    new ObservableCollection<IFileInfoViewModel>(
                        new DirectoryInfo(newDirectory).GetFileSystemInfos().Select(info => new FileInfoViewModel(info)));

                collection.Insert(0, new ParentDirectoryViewModel(Directory.GetParent(newDirectory).FullName)); 
                m_CurrentDir = newDirectory;
                FileInfos = collection;
            }
        }
    }
}
