public class Companion : Collectible<CompanionData>
{
  protected override void AddToInventory(CompanionData data)
  {
    InventoryData.Instance.Add(data);
    switch (data.type)
    {
      case CompanionData.Type.Fairy:
        Global.OnFairyAcquired?.Invoke();
        break;
      case CompanionData.Type.Cat:
        Global.OnCatAcquired?.Invoke();
        break;
      case CompanionData.Type.Ghost:
        Global.OnGhostAcquired?.Invoke();
        break;
    }
  }
}
