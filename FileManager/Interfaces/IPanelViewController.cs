namespace FileManager.ui.Interfaces
{
    public interface IPanelViewController
    {
        void SetLeftPluginOrientation(PluginViewHolder pluginView);
        void SetRightPluginOrientation(PluginViewHolder pluginView);
        void SetPanelVisibility(PluginViewHolder pluginView);
        bool CanSetVisibility();
    }
}