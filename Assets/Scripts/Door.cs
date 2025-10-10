using System.Collections.Generic;
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

  void Update()
  {
    int overlapCount = 0;
    if (Physics2D.OverlapCollider(doormat, doormatFilter, doormatResults) > 0)
    {
      SetDoor(false);
      return;
    }

    // check each point
    foreach (Transform wallPoint in wallPoints)
    {
      if (Physics2D.OverlapCircle(wallPoint.position, checkRadius, 1 << Global.wallLayer))
      {
        overlapCount++;
      }
    }

    SetDoor(overlapCount >= pointsNeededToActivate);
  }

  void SetDoor(bool to)
  {
    if (isActive == to)
    {
      return;
    }

    isActive = to;
    sr.enabled = to;
    col.enabled = to;
  }
}