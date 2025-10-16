using System;
using UnityEngine;

public class WiggleWiggle : MonoBehaviour
{
  public float rotationAmount = 2f;
  public float rotationSpeed = 0.47f;

  private RectTransform rectTransform;
  private float originalRotationZ;

  void Start()
  {
    rectTransform = GetComponent<RectTransform>();
    originalRotationZ = rectTransform.eulerAngles.z;
  }

  void Update()
  {
    float angle = Mathf.Sin(Time.time * rotationSpeed * Mathf.PI * 2) * rotationAmount;
    rectTransform.rotation = Quaternion.Euler(0, 0, originalRotationZ + angle);
  }
}