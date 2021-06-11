using Entitas;
using Entitas.CodeGeneration.Attributes;
using Sources.Services.LoggingService.Interface;

[Meta, Unique]
public class LogServiceComponent : IComponent
{
	public ILogService Instance;
}