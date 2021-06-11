using System;
using System.IO;
using Sources.Services.Interface;
using Sources.Services.LoggingService.Interface;
using UnityEngine;

namespace Sources.Services.LoggingService
{
	public class UnityDebugLogService : ILogService, IService
	{
		string filePath = Application.dataPath + "/ElementsLog.txt";

		public void LogMessage ( string message )
		{
			Debug.Log ( message );
		}

		public void LogWarning ( string message )
		{
			Debug.LogWarning ( message );
		}

		public void LogToFile ( string message, string type )
		{
			if ( File.Exists ( this.filePath ) )
			{
				StreamWriter sr = File.AppendText ( this.filePath );
				sr.WriteLine ( type + ": " + message + " at " + DateTime.Now );
				sr.Close ();
			}
			else
			{
				StreamWriter sr = File.CreateText ( this.filePath );
				sr.WriteLine ( type + ": " + message + " at " + DateTime.Now );
				sr.Close ();
			}
		}

		public void LogError(string message)
		{
			Debug.LogError(message);
		}
	}
}