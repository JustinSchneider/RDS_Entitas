using Sources.Systems.Services.Initialize;

namespace Sources.Systems.Services
{
    public class ServicesSystems : Feature
    {
        public ServicesSystems(Contexts contexts, Sources.Services.Services services) : base("Services Systems")
        {
            // order is respected 
            Add(new RegisterInteractionModeService(contexts, services));
            Add(new RegisterViewSystem(contexts, services));
            Add(new RegisterLoggingServiceSystem(contexts, services));
            Add(new RegisterViewSystem(contexts, services));
        }
    }
}