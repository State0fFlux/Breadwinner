public class Ingredient : Collectible<IngredientData>
{
  protected override void AddToInventory(IngredientData data)
  {
    InventoryData.Instance.Add(data);
  }
}
