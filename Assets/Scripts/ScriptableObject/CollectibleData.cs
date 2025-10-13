using UnityEngine;

public abstract class CollectibleData : ScriptableObject
{
  public Sprite icon;
  public override abstract string ToString(); // returns formatted type name
}