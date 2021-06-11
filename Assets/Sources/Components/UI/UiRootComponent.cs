using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Ui, Unique]
public class UiRootComponent : IComponent
{
	public GameObject Value;
}