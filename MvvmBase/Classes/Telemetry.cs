using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MvvmBase.Classes
{
    public static class Telemetry
    {
        public static int UserId { get; set; }
        private static Guid? _sessionId;

        public static Guid SessionId
        {
            get
            {
                if (!_sessionId.HasValue)
                    _sessionId = Guid.NewGuid();

                return _sessionId.Value;
            }
        }

        public static void SendCommandData(CommandData eventData)
        {
           Debug.WriteLine("User Id: " + UserId.ToString() + Environment.NewLine + "Session Id: " + SessionId.ToString() + Environment.NewLine + "Method to execute: " + eventData.ExecuteMethodName + Environment.NewLine + "Command Name: " + eventData.CommandName);
        }

    }
}
