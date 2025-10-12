using UnityEngine;

public class Door : MonoBehaviour
{
  [SerializeField] private Collider2D doormat;

  // Settings
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
    bool shouldActivate = Physics2D.OverlapCircle(doormat.transform.position, checkRadius, 1 << Global.wallLayer);
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