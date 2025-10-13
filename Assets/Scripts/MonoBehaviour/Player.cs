using UnityEngine;

public class Player : MonoBehaviour
{

  [Header("Player Stats")]
  [SerializeField] int health;


  [HideInInspector]
  public static int bridgesPlayerIsOn = 0;

  public static Player Instance; // Singleton

  void Awake()
  {
    if (Instance != null && Instance != this)
    {
      Destroy(Instance.gameObject);
    } else
    {
      Instance = this;
    }
  }

  void Start()
  {
    // CHEAT CODE: start with cat companion
    CompanionData companion = ScriptableObject.CreateInstance<CompanionData>();
    companion.type = CompanionData.Type.Cat;
    Inventory.AddCompanion(companion);
  }
}