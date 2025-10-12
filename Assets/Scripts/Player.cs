using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
  public int health;
  public int speed;

  // Components
  private Movement movement; // handles movement & inputs

  void Start()
  {
    movement = gameObject.AddComponent<Movement>();
    movement.SetSpeed(speed);
  }
}