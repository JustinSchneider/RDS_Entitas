using Entitas;

namespace Sources.Services.ViewService.Interface
{
    public interface IEventListener {
        void RegisterListeners(IEntity entity);
    }
}