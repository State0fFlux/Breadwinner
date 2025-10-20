using UnityEngine;
public class LevelMaster : KeepNewSingleton<LevelMaster>
{
  public LevelData data;

  protected override void OnEnable()
  {
    base.OnEnable();
    Actions.OnFairyAcquired += ImproveCamera;
  }
  protected override void OnDisable()
  {
    base.OnDisable();
    Actions.OnFairyAcquired -= ImproveCamera;
  }

  void Start()
  {
    InventoryData.Instance.Remove(data.ingredientGoal);
    InventoryData.Instance.Remove(data.companionGoal);
    TransitionMaster.Instance.SetMusic(data.theme);
  }

  void ImproveCamera()
  {
    StartCoroutine(Global.AnimateFloat(
        start: Camera.main.orthographicSize,
        end: Camera.main.orthographicSize * 2,
        onUpdate: value => Camera.main.orthographicSize = value
    ));
  }
}