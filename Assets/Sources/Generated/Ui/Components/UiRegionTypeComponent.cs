//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UiEntity {

    public Sources.Components.UI.RegionTypeComponent regionType { get { return (Sources.Components.UI.RegionTypeComponent)GetComponent(UiComponentsLookup.RegionType); } }
    public bool hasRegionType { get { return HasComponent(UiComponentsLookup.RegionType); } }

    public void AddRegionType(Sources.Constants.UIConstants.Region newValue) {
        var index = UiComponentsLookup.RegionType;
        var component = (Sources.Components.UI.RegionTypeComponent)CreateComponent(index, typeof(Sources.Components.UI.RegionTypeComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceRegionType(Sources.Constants.UIConstants.Region newValue) {
        var index = UiComponentsLookup.RegionType;
        var component = (Sources.Components.UI.RegionTypeComponent)CreateComponent(index, typeof(Sources.Components.UI.RegionTypeComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveRegionType() {
        RemoveComponent(UiComponentsLookup.RegionType);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UiEntity : IRegionTypeEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class UiMatcher {

    static Entitas.IMatcher<UiEntity> _matcherRegionType;

    public static Entitas.IMatcher<UiEntity> RegionType {
        get {
            if (_matcherRegionType == null) {
                var matcher = (Entitas.Matcher<UiEntity>)Entitas.Matcher<UiEntity>.AllOf(UiComponentsLookup.RegionType);
                matcher.componentNames = UiComponentsLookup.componentNames;
                _matcherRegionType = matcher;
            }

            return _matcherRegionType;
        }
    }
}
