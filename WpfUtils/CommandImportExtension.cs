using System;
using System.Windows.Input;

namespace WpfUtils
{
    public class CommandImportExtension : ImportExtension
    {
        public CommandImportExtension(string commandName)
            : base(typeof(ICommand), commandName)
        {
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            object value = base.ProvideValue(serviceProvider);
            var command = value as ICommand;
            return command;
        }
    }
}
