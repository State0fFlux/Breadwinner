using TMPro;
using UnityEngine;

public class Portal : Door
{
  [HideInInspector] public Portal counterpart;
  bool ghostPhase = false;

  void OnEnable()
  {
    Actions.OnGhostAcquired += EnableGhostPhase;
  }
  void OnDisable()
  {
    Actions.OnGhostAcquired -= EnableGhostPhase;
  }

  void EnableGhostPhase()
  {
    ghostPhase = true;
  }

  public override void Enter()
  {
    counterpart.Exit();
  }

  public override void Exit()
  {
    base.Exit();
    if (!ghostPhase)
    {
      SmoothCamera.Instance.SnapToTarget();
    }
  }
}