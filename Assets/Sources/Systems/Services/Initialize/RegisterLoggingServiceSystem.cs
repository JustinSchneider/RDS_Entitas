using Entitas;
using Sources.Services.LoggingService.Interface;

namespace Sources.Systems.Services.Initialize
{
	public class RegisterLoggingServiceSystem : IInitializeSystem
	{
		private readonly ILogService logService;
		private readonly MetaContext metaContext;
		
		public RegisterLoggingServiceSystem (Contexts contexts, global::Sources.Services.Services services)
		{
			this.logService = services.LogService;
			this.metaContext = contexts.meta;
		}
		
		public void Initialize ()
		{
			this.metaContext.ReplaceLogService( this.logService );
		}
	}
}