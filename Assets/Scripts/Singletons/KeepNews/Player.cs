using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Player : KeepNewSingleton<Player>
{
  [HideInInspector] public static int bridgesPlayerIsOn = 0;

  protected override void OnEnable()
  {
    base.OnEnable();
    Global.OnFairyAcquired += ImproveLight;
  }
  protected override void OnDisable()
  {
    base.OnDisable();
    Global.OnFairyAcquired -= ImproveLight;
  }

  void ImproveLight()
  {
    GameObject light = GetComponentInChildren<Light2D>().gameObject;
    Destroy(light);
    Instantiate(InventoryData.Instance.fairyLight, transform);
  }
}