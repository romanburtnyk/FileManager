using System.Collections.Generic;

namespace FileManager.Intf
{
    public class MenuPath
    {
        public MenuPath(List<string> subMenus)
        {
            SubMenus = subMenus;
        }

        public List<string> SubMenus { get; private set; }
    }
}