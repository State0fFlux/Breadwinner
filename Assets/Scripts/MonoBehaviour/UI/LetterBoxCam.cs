using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(Camera))]
public class LetterboxCam : MonoBehaviour
{
  public float targetAspect = 16f / 9f; // your desired aspect ratio (change if needed)
  private Camera cam;

  void Start()
  {
    cam = GetComponent<Camera>();
    UpdateViewport();
  }

  void Update()
  {
    UpdateViewport();
  }

  void UpdateViewport()
  {
    float windowAspect = (float)Screen.width / (float)Screen.height;
    float scaleHeight = windowAspect / targetAspect;

    if (scaleHeight < 1.0f)
    {
      // Letterbox: black bars top and bottom
      Rect rect = cam.rect;
      rect.width = 1.0f;
      rect.height = scaleHeight;
      rect.x = 0;
      rect.y = (1.0f - scaleHeight) / 2.0f;
      cam.rect = rect;
    }
    else
    {
      // Pillarbox: black bars on left and right
      float scaleWidth = 1.0f / scaleHeight;
      Rect rect = cam.rect;
      rect.width = scaleWidth;
      rect.height = 1.0f;
      rect.x = (1.0f - scaleWidth) / 2.0f;
      rect.y = 0;
      cam.rect = rect;
    }
  }
}
