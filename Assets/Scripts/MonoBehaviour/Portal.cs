using UnityEngine;

public class Portal : Door
{
  public Portal counterpart;
  public override void Enter()
  {
    counterpart.Exit();
  }
}