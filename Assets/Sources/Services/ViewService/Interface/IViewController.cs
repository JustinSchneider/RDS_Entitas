using Entitas;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace Sources.Services.ViewService.Interface
{
    public interface IViewController
    {
        
        //Transform properties
        Transform Transform { get; }
        Vector3 Position { get; set; }
        Vector3 Scale { get; set; }
        Vector3 Rotation { get; set; }
        Color32 ViewColor{ get; set; }
        Color32 OriginalColor{ get; }
        //Manipulation
        void Rotate(Vector3 rotationVector, int index = 0);

        Renderer Renderer { get; }
        bool Active { get; set; }
        void InitializeView(IEntity entity);
        void DestroyView();
    }
}