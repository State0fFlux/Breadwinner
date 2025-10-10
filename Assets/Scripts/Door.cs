using UnityEngine;

public class Door : MonoBehaviour
{
  [Header("Detection Points")]
  [SerializeField] private Transform[] wallPoints;
  [SerializeField] private Collider2D doormat;

  // Settings
  private int pointsNeededToActivate = 2;
  private float checkRadius = 0.05f; // for small overlap tolerance
  private bool isActive = false;

  // Components
  private Collider2D col;
  private SpriteRenderer sr;
  private ContactFilter2D doormatFilter;
  private Collider2D[] doormatResults = new Collider2D[1];

  void Awake()
  {
    col = GetComponent<Collider2D>();
    sr = GetComponent<SpriteRenderer>();
    doormatFilter = new ContactFilter2D();
    doormatFilter.SetLayerMask(1 << Global.bridgeLayer);
    doormatFilter.useTriggers = true;
  }

  void Start()
  {
    SetDoor(false);
  }

  void Update()
  {
    if (Physics2D.OverlapCollider(doormat, doormatFilter, doormatResults) > 0)
    {
      SetDoor(false);
      return;
    }

    int overlapCount = 0;
    // check each point
    foreach (Transform wallPoint in wallPoints)
    {
      if (Physics2D.OverlapCircle(wallPoint.position, checkRadius, 1 << Global.wallLayer))
      {
        overlapCount++;
      }
    }

    bool shouldActivate = overlapCount >= pointsNeededToActivate;
    if (shouldActivate != isActive)
    {
      SetDoor(shouldActivate);
    }
  }

  void SetDoor(bool to)
  {
    isActive = to;
    col.enabled = to;
    sr.color = to ? Color.white : Color.clear;
  }
}