using System;
using System.ComponentModel.Composition;
using System.Windows.Input;

namespace WpfUtils
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CommandExportAttribute : ExportAttribute
    {
        public CommandExportAttribute(string commandName) :
            base(commandName, typeof(ICommand))
        {
        }
    }
}
