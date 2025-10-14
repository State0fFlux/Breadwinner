using UnityEngine;

public class Player : MonoBehaviour
{
  public PlayerData playerData;
  public Inventory inventory;
  [HideInInspector] public GameObject lantern;
  [HideInInspector] public static int bridgesPlayerIsOn = 0;

  public static Player Instance;

  void OnEnable()
  {
    Inventory.Instance.OnInventoryChanged += SetupLantern;
    Instance = this;
  }
  void OnDisable()
  {
    Inventory.Instance.OnInventoryChanged -= SetupLantern;
    Instance = null;
  }

  void Start()
  {
    SetupLantern();
    /*
    // CHEAT CODE: start with cat companion
    CompanionData companion = ScriptableObject.CreateInstance<CompanionData>();
    companion.type = CompanionData.Type.Cat;
    inventory.AddCompanion(companion);
    */
  }

  public void SetupLantern()
  {
    if (lantern != null) Destroy(lantern);

    if (Inventory.Instance.HasCompanion(CompanionData.Type.Fairy))
      lantern = Instantiate(Inventory.Instance.upgradedLantern, transform);
    else
      lantern = Instantiate(Inventory.Instance.basicLantern, transform);
  }
}