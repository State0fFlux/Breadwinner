using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
  public static Player Instance; // Singleton
  public int health;
  public int speed;

  // Components
  private Movement movement; // handles movement & inputs

  void Start()
  {
    if (Instance != null && Instance != this)
    {
      Destroy(Instance.gameObject); // keep the newest player
    }
    Instance = this;
    movement = gameObject.AddComponent<Movement>();
    movement.SetSpeed(speed);

    // CHEAT CODE: start with cat companion
    Global.AddCompanion(Global.Companion.Cat);
  }
}