using UnityEngine;

[CreateAssetMenu(fileName = "NewIngredient", menuName = "Inventory/Ingredient")]
public class IngredientData : CollectibleData
{
  public enum Type
  {
    Salt,
    Flour,
    Yeast
  }

  public Type type;
  public int needed = 1;

  public override string ToString()
  {
    return Global.FormatEnumName(type);
  }
}