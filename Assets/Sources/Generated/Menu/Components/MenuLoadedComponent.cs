//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class MenuEntity {

    static readonly Sources.Components.UI.Menu.LoadedComponent loadedComponent = new Sources.Components.UI.Menu.LoadedComponent();

    public bool isLoaded {
        get { return HasComponent(MenuComponentsLookup.Loaded); }
        set {
            if (value != isLoaded) {
                var index = MenuComponentsLookup.Loaded;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : loadedComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class MenuMatcher {

    static Entitas.IMatcher<MenuEntity> _matcherLoaded;

    public static Entitas.IMatcher<MenuEntity> Loaded {
        get {
            if (_matcherLoaded == null) {
                var matcher = (Entitas.Matcher<MenuEntity>)Entitas.Matcher<MenuEntity>.AllOf(MenuComponentsLookup.Loaded);
                matcher.componentNames = MenuComponentsLookup.componentNames;
                _matcherLoaded = matcher;
            }

            return _matcherLoaded;
        }
    }
}
