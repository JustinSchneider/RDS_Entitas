using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class CombatStatComponent : IComponent
{
    public float MaxHealth;
    public float CurrentHealth;
    public float Attack;
    public float AttackVariance;
}
