using System;
using System.Reflection;
using System.Windows.Markup;

namespace WpfUtils
{
    public class ImportExtension : MarkupExtension
    {
        private static MethodInfo ms_GetExportedValueTypeMethod;
        private static MethodInfo ms_GetExportedValueTypeContractMethod;

        public ImportExtension(Type type)
            : this(type, null)
        {
        }

        public ImportExtension(Type type, string contract)
        {
            Type = type;
            Contract = contract;
        }

        public Type Type
        {
            get;
            set;
        }

        public string Contract
        {
            get;
            set;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (ms_GetExportedValueTypeMethod == null || ms_GetExportedValueTypeContractMethod == null)
            {
                ms_GetExportedValueTypeMethod = typeof(CompositionService).GetMethod("GetExportedValue", Type.EmptyTypes);
                ms_GetExportedValueTypeContractMethod = typeof(CompositionService).GetMethod("GetExportedValue", new Type[] { typeof(string) });
            }

            bool hasContract = !string.IsNullOrEmpty(Contract);
            MethodInfo invokeMethod = hasContract ? ms_GetExportedValueTypeContractMethod.MakeGenericMethod(Type) :
                ms_GetExportedValueTypeMethod.MakeGenericMethod(Type);

            return invokeMethod.Invoke(null, hasContract ? new object[] { Contract } : null);
        }
    }
}