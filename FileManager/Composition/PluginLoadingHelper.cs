using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FileManager.Intf;
using Version = FileManager.Intf.Version;

namespace FileManager.ui
{
    internal class PluginLoadingHelper
    {
        public static List<IPlugin> GetValidPlugins(List<IPlugin> oldPlugins, Version version)
        {
            var newPlugins = oldPlugins
                .Where(plugin => IsPluginSupported(plugin, version))
                //Find max version of plugin
                .GroupBy(plugin => plugin.Uid)
                .Select(FindMaxVersionPlugin)
                .ToList();
            return newPlugins;
        }

        private static IPlugin FindMaxVersionPlugin(IGrouping<string, IPlugin> plugins)
        {
            Debug.Assert(plugins.Any());
            var maxVersionPlugin = plugins.First();
            foreach (var plugin in plugins)
            {
                if (maxVersionPlugin.Version.CompareTo(plugin.Version) == -1)
                {
                    Logger.Instance.Log(String.Format("Found previous version of plugin.       Current version:" + PluginTostring(plugin) +
                        "          Previous version: " + PluginTostring(maxVersionPlugin)), LogPriority.Warning);
                    maxVersionPlugin = plugin;
                }
                else
                {
                    if (maxVersionPlugin != plugin)
                    {
                        Logger.Instance.Log(String.Format("Found previous version of plugin.     Current version: " +
                                          PluginTostring(maxVersionPlugin) +"        Previous version: " + PluginTostring(plugin)), LogPriority.Warning);
                    }
                }
            }
            return maxVersionPlugin;
        }

        private static bool IsPluginSupported(IPlugin plugin, Version version)
        {
            bool result = plugin.SupportedManagerVersion.IsCompartibleWith(version);
            if (!result)
            {
                Logger.Instance.Log(String.Format(String.Format("Not compatible plugin. Aplication version: {0}, Plugin: ({1})",
                    version, PluginTostring(plugin))), LogPriority.Warning);;
            }
            return result;
        }


        public static string PluginTostring(IPlugin plugin)
        {
            return
                String.Format("Name: {0}, Version: {1}, Uid: {2}, Application compatible version: {3}",
                    plugin.Name, plugin.Version, plugin.Uid, plugin.SupportedManagerVersion);
        }
    }
}