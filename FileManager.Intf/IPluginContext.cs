using System;
using System.Collections.Generic;
using System.IO;

namespace FileManager.Intf
{
    public interface IPluginContext
    {
        event EventHandler<PropertyEventArgs> PropertyChanged;
        DirectoryInfo Current { get; set; }
        List<FileInfo> FileList { get; set; }
        List<FileInfo> SelectedFiles { get; set; }
    }

    public class PropertyEventArgs:EventArgs
    {
        public PropertyEventArgs(string property)
        {
            Property = property;
        }

        public string Property { get; private set; }
    }
}