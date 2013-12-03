namespace FileViewerPlugin
{
    public interface IFileInfoViewModel
    {
        string Name { get; set; }
        string FullName { get; }
        long Length { get; }
        bool IsDirectory { get; }
    }
}