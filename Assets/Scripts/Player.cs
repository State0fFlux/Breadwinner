using Unity.VisualScripting;
using UnityEngine;

public class Player: MonoBehaviour
{
  public static Player Instance { get; private set; } // Singleton instance
  public int health = 3;

  // Components
  private Movement movement; // handles movement & inputs

  void Start()
  {
    if (Instance != null) // keep the old copy
    {
      Destroy(gameObject);
      return;
    }
    Instance = this;
    DontDestroyOnLoad(gameObject);
    movement = gameObject.AddComponent<Movement>();
  }
}