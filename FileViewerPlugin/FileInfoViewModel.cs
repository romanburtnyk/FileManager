using System.IO;

namespace FileViewerPlugin
{
    public class FileInfoViewModel:ViewModel
    {
        private readonly FileSystemInfo m_Info;
        private bool m_IsDirectory;
        private long m_Length;
        private string m_Name;
        private string m_FullName;

        public FileInfoViewModel(FileSystemInfo info)
        {
            m_Info = info;
            m_IsDirectory = (info.Attributes & FileAttributes.Directory) == FileAttributes.Directory;

            var fileInfo = m_Info as FileInfo;
            m_Length = (fileInfo != null)? fileInfo.Length: 0;
            m_Name = info.Name;
            FullName = info.FullName;
        }


        public string Name
        {
            get { return m_Name; }
            set
            {
                if (value == m_Name) return;
                m_Name = value;
                RenameFile(value);
                OnPropertyChanged();
            }
        }

        private void RenameFile(string name)
        {
            if (IsDirectory)
            {
                Directory.Move(FullName, Directory.GetParent(FullName) +"\\" + name);
            }
            else
            {
                File.Move(FullName, Directory.GetParent(FullName) + "\\" + name);
            }
            m_Info.Refresh();
            FullName = m_Info.FullName;
        }

        public string FullName
        {
            get { return m_FullName; }
            private set
            {
                if (value == m_FullName) return;
                m_FullName = value;
                OnPropertyChanged();
            }
        }

        public long Length
        {
            get { return m_Length; }
        }

        public bool IsDirectory
        {
            get { return m_IsDirectory; }
        }
    }
}