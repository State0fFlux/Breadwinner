using UnityEngine;

public class Cogwheel : MonoBehaviour
{
  [Header("Cog Settings")]
  [SerializeField] private float turnMultiplier = 1f;
  
  private const float targetRPM = 10f;
  private float radius;

  void Start()
  {
    // Calculate radius from sprite size (assuming pivot at center)
    SpriteRenderer sr = GetComponent<SpriteRenderer>();
    radius = sr.bounds.size.x / 2f;
  }

  void FixedUpdate()
  {
    // Adjust angular speed by radius
    float rpmAdjusted = targetRPM / radius * turnMultiplier;
    float degreesPerSecond = rpmAdjusted * 6f; // RPM -> degrees/sec
    transform.Rotate(0f, 0f, -degreesPerSecond * Time.fixedDeltaTime);
  }
}
