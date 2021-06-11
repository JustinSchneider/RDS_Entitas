namespace Sources.Services.LoggingService.Interface
{
	public interface ILogService
	{
		void LogMessage(string message);
		void LogWarning ( string message );
		void LogError (string message);
		void LogToFile (string message, string type);


	}
}