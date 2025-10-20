using UnityEngine;
using UnityEngine.Rendering;

public class Accessory : MonoBehaviour
{
  private SpriteRenderer sr;

  void Awake()
  {
    sr = GetComponent<SpriteRenderer>();
  }

  void OnEnable()
  {
    Actions.OnCompanionAcquired += Dress;
  }
  void OnDisable()
  {
    Actions.OnCompanionAcquired -= Dress;
  }

  void Dress(CompanionData companion)
  {
    sr.sprite = companion.accessoryOnPlayer;
  }
}