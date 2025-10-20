public class Companion : Collectible<CompanionData>
{
  protected override void AddToInventory(CompanionData data)
  {
    InventoryData.Instance.Add(data);
    Actions.OnCompanionAcquired?.Invoke(data);
  }
}
