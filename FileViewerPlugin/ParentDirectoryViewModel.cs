namespace FileViewerPlugin
{
    class ParentDirectoryViewModel : IFileInfoViewModel
    {
        private readonly string m_FullPath;

        public ParentDirectoryViewModel(string fullPath)
        {
            m_FullPath = fullPath;
        }

        public string Name
        {
            get { return ".."; }
            set { }
        }

        public string FullName { get { return m_FullPath; } }
        public long Length { get { return 0; } }
        public bool IsDirectory { get { return true; } }
    }
}