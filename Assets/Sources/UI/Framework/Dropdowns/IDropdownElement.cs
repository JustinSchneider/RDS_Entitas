using Sources.UI.Framework.Base;
using TMPro;

namespace Sources.UI.Framework.Dropdowns
{
    public interface IDropdownElement : IUiElement
    {
        TMP_Dropdown UnityDropdown { get; }
    }
}
