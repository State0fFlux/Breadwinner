using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Player : KeepNewSingleton<Player>
{
  private GameObject lantern;
  [HideInInspector] public static int bridgesPlayerIsOn = 0;

  protected override void OnEnable()
  {
    base.OnEnable();
    InventoryData.Instance.OnInventoryChanged += UpdateLantern;
  }
  protected override void OnDisable()
  {
    base.OnDisable();
    InventoryData.Instance.OnInventoryChanged -= UpdateLantern;
  }

  void Awake()
  {
    lantern = GetComponentInChildren<Light2D>()?.gameObject;
  }

  void Start()
  {
    UpdateLantern();
  }

  private void UpdateLantern()
  {
    if (LevelMaster.Instance.data.companionGoal.type != CompanionData.Type.Fairy) // not a dark level
    {
      return;
    }

    GameObject expected = InventoryData.Instance.HasCompanion(CompanionData.Type.Fairy) ? InventoryData.Instance.upgradedLantern : InventoryData.Instance.basicLantern;
    if (!lantern) // make a new lantern
    {
      lantern = Instantiate(expected, transform);
      return;
    }
    else if (lantern.name.Contains(expected.name)) // no need to replace!
    {
      return;
    }
    else
    {
      Destroy(lantern);
      lantern = Instantiate(expected, transform);
      return;
    }
  }
}