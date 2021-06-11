using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Sources.Components.Meta {
    [Meta, Unique]
    public class MainCameraGameObjectComponent : IComponent
    {
        public GameObject Value;
    }
}
