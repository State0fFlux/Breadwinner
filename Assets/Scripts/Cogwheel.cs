using UnityEngine;

public class Cogwheel : MonoBehaviour
{
  private float baseSpeed = 60f;
  [SerializeField] private float turnMultiplier = 1f;

  void FixedUpdate()
  {
    transform.Rotate(0, 0, -baseSpeed * turnMultiplier * Time.fixedDeltaTime);
  }
}