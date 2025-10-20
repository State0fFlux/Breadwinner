using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Player : KeepNewSingleton<Player>
{
  public Movement Movement;
  [HideInInspector] public static int bridgesPlayerIsOn = 0;
  public int speed = 30;

  protected override void OnEnable()
  {
    base.OnEnable();
    Actions.OnFairyAcquired += ImproveLight;
    Movement = gameObject.AddComponent<Movement>();
  }
  protected override void OnDisable()
  {
    base.OnDisable();
    Actions.OnFairyAcquired -= ImproveLight;
    Destroy(Movement);
  }

  void ImproveLight()
  {
    GameObject light = GetComponentInChildren<Light2D>().gameObject;
    Destroy(light);
    Instantiate(InventoryData.Instance.fairyLight, transform);
  }
}