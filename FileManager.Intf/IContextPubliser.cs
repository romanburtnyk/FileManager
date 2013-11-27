using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Intf
{
    public interface IContextPubliser
    {
        void PublishContext<T>(T context);
        T GetContext<T>();
    }
}


