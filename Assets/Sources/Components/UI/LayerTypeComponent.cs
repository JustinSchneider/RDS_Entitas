using Entitas;
using Entitas.CodeGeneration.Attributes;
using Sources.Constants;

namespace Sources.Components.UI {
    [Ui]
    public class LayerTypeComponent : IComponent
    {
        [PrimaryEntityIndex]
        public UIConstants.Layer Value;
    }
}
