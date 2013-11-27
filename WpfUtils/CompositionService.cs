using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
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
                    ms_Container = getContainer();
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
                    ms_Container.Compose(batch);
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
                    result = ms_Container.GetExportedValue<T>();
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
                    result = ms_Container.GetExportedValue<T>(contractName);
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
                    ms_Container.ComposeParts(value);
                }
            }
        }
    }
}