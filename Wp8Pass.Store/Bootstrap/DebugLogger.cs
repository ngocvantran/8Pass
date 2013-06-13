using System;
using System.Diagnostics;
using Caliburn.Micro;

namespace Wp8Pass.Store.Bootstrap
{
    internal class DebugLogger : ILog
    {
        private readonly string _type;

        public DebugLogger(Type type)
        {
            _type = type.FullName;
        }

        public void Error(Exception exception)
        {
            Debug.WriteLine("[{0}] ERROR: {1}", _type, exception);
        }

        public void Info(string format, params object[] args)
        {
            Debug.WriteLine(_type + "=> INFO " + format, args);
        }

        public void Warn(string format, params object[] args)
        {
            Debug.WriteLine(_type + "=> WARN " + format, args);
        }
    }
}