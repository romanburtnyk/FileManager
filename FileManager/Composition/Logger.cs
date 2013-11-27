namespace FileManager.ui
{
    internal class Logger
    {
        private static ILogger m_Instance;
        private static object m_SyncObject = new object();

        public static ILogger Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    lock (m_SyncObject)
                    {
                        if (m_Instance == null)
                            m_Instance = new PluginLogger();
                    }
                }
                return m_Instance;
            }
        }
    }
}