using UnityEngine;

public class Portal : Door
{
  [HideInInspector] public Portal counterpart;
  public override void Enter()
  {
    counterpart.Exit();
  }

  public override void Exit()
  {
    base.Exit();
    if (!Inventory.Instance.HasCompanion(CompanionData.Type.Ghost))
    {
      SmoothCamera.Instance.SnapToTarget();
    }
  }
}