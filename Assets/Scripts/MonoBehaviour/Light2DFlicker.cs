using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Light2D))]
public class Light2DFlicker : MonoBehaviour
{
  public float flickerAmplitude = 0.2f; // how much it changes
  public float flickerSpeed = 0.1f; // how fast it changes

  private Light2D light2D;
  private float targetIntensity;
  private float baseIntensity;

  void Awake()
  {
    light2D = GetComponent<Light2D>();
    targetIntensity = light2D.intensity;
    baseIntensity = light2D.intensity;
  }

  void Update()
  {
    // Smoothly lerp toward a new random intensity over time
    light2D.intensity = Mathf.Lerp(light2D.intensity, targetIntensity, Time.deltaTime * flickerSpeed);

    if (Mathf.Abs(light2D.intensity - targetIntensity) < 0.05f) // set a new target
      targetIntensity = baseIntensity + Random.Range(-flickerAmplitude, flickerAmplitude);
  }
}
