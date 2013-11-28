using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace FileManager.Intf
{
    public interface IPluginContext: INotifyPropertyChanged
    {
        DirectoryInfo Current { get; set; }
        List<FileSystemInfo> FileList { get; set; }
        List<FileInfo> SelectedFiles { get; set; }
    }
}