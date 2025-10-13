using UnityEngine;

public class PortalPair : MonoBehaviour
{
  [SerializeField] private Portal a;
  [SerializeField] private Portal b;

  void Start()
  {
    a.counterpart = b;
    b.counterpart = a;
  }
}