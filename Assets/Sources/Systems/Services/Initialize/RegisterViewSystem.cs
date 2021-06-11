using Entitas;
using Sources.Services.ViewService.Interface;

namespace Sources.Systems.Services.Initialize
{
    public class RegisterViewSystem : IInitializeSystem
    {
        private readonly MetaContext metaContext;

        private readonly IViewService symbolViewService;
        private readonly IViewService textViewService;
        private readonly IViewService lineViewService;
        private readonly IViewService gripViewService;
        private readonly IViewService polygonViewService;

        public RegisterViewSystem(Contexts contexts, global::Sources.Services.Services services)
        {
            this.metaContext = contexts.meta;
            this.symbolViewService = services.SymbolViewService;
            this.textViewService = services.TextViewService;
            this.lineViewService = services.LineViewService;
            this.gripViewService = services.GripViewService;
            this.polygonViewService = services.PolygonViewService;
        }

        public void Initialize()
        {
        }
    }
}