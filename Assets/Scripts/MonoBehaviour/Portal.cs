using UnityEngine;

public class Portal : Door
{
  [HideInInspector] public Portal counterpart;
  public override void Enter()
  {
    counterpart.Exit();
  }
}