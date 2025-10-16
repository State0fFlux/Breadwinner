using UnityEngine;

public class Player : MonoBehaviour
{
  public PlayerData playerData;
  public Inventory inventory;
  public GameObject lantern;
  [HideInInspector] public static int bridgesPlayerIsOn = 0;

  public static Player Instance;

  void OnEnable()
  {
    if (Instance != null && Instance != this)
    {
      Destroy(Instance.gameObject);
    }
    Instance = this;
    Inventory.Instance.OnInventoryChanged += SetupLantern;
  }
  void OnDisable()
  {
    Instance = null;
    Inventory.Instance.OnInventoryChanged -= SetupLantern;
  }

  void Start()
  {
    if (!lantern.activeInHierarchy)
    {
      Destroy(lantern);
      lantern = null;
    }
    SetupLantern();
  }

  public void SetupLantern()
  {
    if (lantern == null)
    {
      return;
    }

    GameObject expected = Inventory.Instance.HasCompanion(CompanionData.Type.Fairy) ? Inventory.Instance.upgradedLantern : Inventory.Instance.basicLantern;
    if (lantern.name.Contains(expected.name)) // no need to replace!
    {
      return;
    }
    Destroy(lantern);
    lantern = Instantiate(expected, transform);
  }
}