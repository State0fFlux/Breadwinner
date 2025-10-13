using UnityEngine;

[CreateAssetMenu(fileName = "NewCompanion", menuName = "Inventory/Companion")]
public class CompanionData : CollectibleData
{
  public enum Type
  {
    Fairy,
    Cat,
    Ghost
  }

  public Type type;
  public override string ToString()
  {
    return Global.FormatEnumName(type);
  }
}