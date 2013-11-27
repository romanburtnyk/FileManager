using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using FileManager.Intf;

namespace FileManager.ui
{
    [PartCreationPolicy(CreationPolicy.Shared)]
    [Export(typeof(IPluginContext))]
    internal class PluginContext : IPluginContext
    {
        public event EventHandler<PropertyEventArgs> PropertyChanged;
        public DirectoryInfo Current { get; set; }
        public List<FileInfo> FileList { get; set; }
        public List<FileInfo> SelectedFiles { get; set; }
    }
}