//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class MenuEntity {

    public Sources.Components.UI.RegionTypeComponent regionType { get { return (Sources.Components.UI.RegionTypeComponent)GetComponent(MenuComponentsLookup.RegionType); } }
    public bool hasRegionType { get { return HasComponent(MenuComponentsLookup.RegionType); } }

    public void AddRegionType(Sources.Constants.UIConstants.Region newValue) {
        var index = MenuComponentsLookup.RegionType;
        var component = (Sources.Components.UI.RegionTypeComponent)CreateComponent(index, typeof(Sources.Components.UI.RegionTypeComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceRegionType(Sources.Constants.UIConstants.Region newValue) {
        var index = MenuComponentsLookup.RegionType;
        var component = (Sources.Components.UI.RegionTypeComponent)CreateComponent(index, typeof(Sources.Components.UI.RegionTypeComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveRegionType() {
        RemoveComponent(MenuComponentsLookup.RegionType);
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
public partial class MenuEntity : IRegionTypeEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class MenuMatcher {

    static Entitas.IMatcher<MenuEntity> _matcherRegionType;

    public static Entitas.IMatcher<MenuEntity> RegionType {
        get {
            if (_matcherRegionType == null) {
                var matcher = (Entitas.Matcher<MenuEntity>)Entitas.Matcher<MenuEntity>.AllOf(MenuComponentsLookup.RegionType);
                matcher.componentNames = MenuComponentsLookup.componentNames;
                _matcherRegionType = matcher;
            }

            return _matcherRegionType;
        }
    }
}
