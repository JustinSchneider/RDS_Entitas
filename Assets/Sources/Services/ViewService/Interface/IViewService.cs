using Entitas;
using UnityEngine;

namespace Sources.Services.ViewService.Interface
{
    public interface IViewService
    {
        // create a view from a premade asset (e.g. a prefab)
        void LoadAsset(IEntity entity);
        void SetColor(IViewController viewController, Color32 color);
    }
}