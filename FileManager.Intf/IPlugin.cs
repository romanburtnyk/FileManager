using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace FileManager.Intf
{
    public interface IPlugin : IDisposable
    {
        Version SupportedManagerVersion { get; }
        Version Version { get; }
        string Name { get; }
        string Uid { get; }
        string Description { get; }

        void ApplyPlugin();

    }
}
