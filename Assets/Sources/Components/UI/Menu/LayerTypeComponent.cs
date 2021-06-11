using Entitas;
using Sources.Constants;

namespace Sources.Components.UI.Menu {
    [Menu]
    public class LayerTypeComponent : IComponent
    {
        public UIConstants.Layer Value;
    }
}
