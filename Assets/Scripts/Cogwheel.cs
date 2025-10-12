using UnityEngine;

public class Cogwheel : MonoBehaviour
{
  [Header("Cog Settings")]
  [SerializeField] private float turnMultiplier = 1f;

  private const float targetRPM = 10f;
  private float radius;
  private Color originalColor;

  // Components
  private SpriteRenderer sr;

  void Start()
  {
    sr = GetComponent<SpriteRenderer>();
    originalColor = sr.color;

    // Calculate radius from sprite size (assuming pivot at center)
    radius = sr.bounds.size.x / 2f;
  }


  void OnMouseEnter()
  {
    if (CanEat())
    {

    }
    sr.color = Color.black; // highlight on hover
  }

  void OnMouseExit()
  {
    if (CanEat())
    {
      sr.color = originalColor; // revert color
    }
  }

  void OnMouseDown()
  {
    if (CanEat())
    {
      print("Om nom nom");
    }
  }

  bool CanEat()
  {
    return Global.HasCompanion(Global.Companion.Cat);
  }

  void FixedUpdate()
  {
    // Adjust angular speed by radius
    float rpmAdjusted = targetRPM / radius * turnMultiplier;
    float degreesPerSecond = rpmAdjusted * 6f; // RPM -> degrees/sec
    transform.Rotate(0f, 0f, -degreesPerSecond * Time.fixedDeltaTime);
  }
}
