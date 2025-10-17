using UnityEngine;
using UnityEngine.UI;

public abstract class CollectibleData : ScriptableObject
{
  public Sprite collectibleIcon;
  public override abstract string ToString(); // returns formatted type name
}