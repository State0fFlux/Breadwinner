using UnityEngine;

public class Bulkhead : MonoBehaviour
{
  [SerializeField] private Collider2D doormat;

  // Settings
  private float checkRadius = 0.05f; // for small overlap tolerance
  private bool isActive = false;

  // Components
  private Collider2D col;
  private ContactFilter2D doormatFilter;
  private Collider2D[] doormatResults = new Collider2D[1];

  void Awake()
  {
    col = GetComponent<Collider2D>();
    doormatFilter = new ContactFilter2D();
    doormatFilter.SetLayerMask(1 << Global.bridgeLayer);
    doormatFilter.useTriggers = true;
  }

  void Start()
  {
    OpenDoor();
  }

  void Update()
  {
    if (Physics2D.OverlapCollider(doormat, doormatFilter, doormatResults) > 0)
    {
      OpenDoor();
      return;
    }
    bool shouldActivate = Physics2D.OverlapCircle(doormat.transform.position, checkRadius, 1 << Global.wallLayer);
    if (shouldActivate != isActive)
    {
      if (shouldActivate)
      {
        CloseDoor();
      }
      else
      {
        OpenDoor();
      }
    }
  }

  void OpenDoor()
  {
    SetDoor(false);
  }

  void CloseDoor()
  {
    SetDoor(true);
  }

  void SetDoor(bool to)
  {
    isActive = to;
    col.enabled = to;
  }
}