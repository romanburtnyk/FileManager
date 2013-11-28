using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Reflection;

namespace WpfUtils
{
    public static class CompositionService
    {
        private static CompositionContainer ms_Container;
        private static readonly object ms_SyncObject = new object();


        public static void Configure(Func<CompositionContainer> getContainer)
        {
            lock (ms_SyncObject)
            {
                if (getContainer != null)
                {
                    ms_Container = new CompositionContainer();
                }
            }
        }
        
        public static void AddExport<T>(T value)
        {
            lock (ms_SyncObject)
            {
                if (ms_Container != null)
                {
                    var batch = new CompositionBatch();
                    var contractName = AttributedModelServices.GetContractName(typeof (T));
                    batch.AddExport(new Export(contractName, () => value));
                    GetContainer().Compose(batch);
                }
            }
        }


        public static T GetExportedValue<T>()
        {
            T result = default (T);
            lock (ms_SyncObject)
            {
                if (ms_Container != null)
                {
                    result = GetContainer().GetExportedValue<T>();
                }
            }
            return result;
        }

        public static T GetExportedValue<T>(string contractName)
        {
            T result = default(T);
            lock (ms_SyncObject)
            {
                if (ms_Container != null)
                {
                    result = GetContainer().GetExportedValue<T>(contractName);
                }
            }
            return result;
        }

        public static void ComposeExportedValue<T>(T value)
        {
            lock (ms_SyncObject)
            {
                if (ms_Container != null)
                {
                    GetContainer().ComposeParts(value);
                }
            }
        }


        private static CompositionContainer GetContainer()
        {
            return ms_Container;
        }

    }
}