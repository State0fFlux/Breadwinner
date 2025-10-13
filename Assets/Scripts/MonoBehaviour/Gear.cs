using Unity.VisualScripting;
using UnityEngine;

public class Gear : MonoBehaviour
{
  [Header("Gear Settings")]
  [SerializeField] private float turnMultiplier = 1f;
  [SerializeField] private GearSet gearSet;
  [SerializeField] private int currentStage;

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
    print(radius);
  }

  void Update()
  {
    // TODO: Figure out how to best show hovering effect
    //CheckMouseHover();
  }

  void FixedUpdate()
  {
    // Adjust angular speed by radius
    float rpmAdjusted = targetRPM / radius * turnMultiplier;
    float degreesPerSecond = rpmAdjusted * 6f; // RPM -> degrees/sec
    transform.Rotate(0f, 0f, -degreesPerSecond * Time.fixedDeltaTime);
  }

  void OnMouseDown()
  {
    if (CanEat())
    {
      Eat();
    }
  }

  void CheckMouseHover()
  {
    if (!CanEat())
    {
      sr.color = originalColor; // reset if not edible
      return;
    }

    // Get mouse position in world space
    Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    mouseWorld.z = 0f; // ignore z for 2D

    // Check if mouse is inside the sprite bounds
    if (sr.bounds.Contains(mouseWorld))
    {
      sr.color = Color.black; // highlight while hovering
    }
    else
    {
      sr.color = originalColor; // reset when not hovering
    }
  }

  bool CanEat()
  {
    if (!gearSet.edible || currentStage >= gearSet.gearPrefabs.Length || !Inventory.HasCompanion(CompanionData.Type.Cat))
    {
      return false; // not edible or already fully eaten
    }
    float distance = Global.CalculateDistance(Player.Instance.transform.position, transform.position);
    return distance > radius && distance <= 2.5f + radius;
  }

  void Eat()
  {
    // TODO: rework system to better adjust collider (don't clone!)
    if (gearSet == null)
    {
      Debug.LogError("GearSet not assigned!");
      return;
    }

    if (currentStage >= gearSet.gearPrefabs.Length - 1)
    {
      Debug.Log($"{name} is fully eaten!");
      return;
    }

    GameObject nextPrefab = gearSet.gearPrefabs[currentStage + 1];

    // Preserve transform
    Transform t = transform;
    Vector3 pos = t.position;
    Quaternion rot = t.rotation;
    Transform parent = t.parent;

    // Replace gear
    Destroy(gameObject);
    GameObject newGear = Instantiate(nextPrefab, pos, rot, parent);
    newGear.transform.localScale = t.localScale; // keep same scale

    // Transfer data
    Gear script = newGear.GetComponent<Gear>();
    if (script != null)
    {
      script.turnMultiplier = turnMultiplier; // keep same speed
      script.gearSet = gearSet; // use same theme
    }
  }
}
