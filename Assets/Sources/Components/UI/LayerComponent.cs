using Entitas;
using Sources.Constants;
using Sources.UI.Framework.Layers;

namespace Sources.Components.UI {
    [Ui]
    public class LayerComponent : IComponent
    {
        public IUiLayer Value;
    }
}
