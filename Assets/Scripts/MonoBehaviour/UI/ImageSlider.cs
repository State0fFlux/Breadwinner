using UnityEngine;
using System.Collections;

public class ImageSlider : MonoBehaviour
{
  private Vector3 originalPosition;
  public Vector3 offscreenOffset = new Vector3(0, -1000, 0);  // Move off screen downward
  public float moveDuration = 0.5f;

  private void Start()
    {
        originalPosition = transform.localPosition;
    }
  // private void Awake()
  // {
  //   rectTransform = GetComponent<RectTransform>();
  //   canvasRect = rectTransform.root.GetComponent<RectTransform>();
  // }

  private System.Collections.IEnumerator MoveToPosition(Vector3 target)
    {
        Vector3 start = transform.localPosition;
        float timeElapsed = 0f;

        while (timeElapsed < moveDuration)
        {
            transform.localPosition = Vector3.Lerp(start, target, timeElapsed / moveDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = target;
    }

  public void SlideOff(float duration = 0.25f)
  {
    StopAllCoroutines();
    StartCoroutine(MoveToPosition(originalPosition + offscreenOffset));
  }

  // public IEnumerator SlideOffCoroutine(float duration = 0.25f)
  // {
  //   Vector2 offscreen = GetEdgePosition(offscreen: true);
  //   yield return SlideTransform(rectTransform, rectTransform.anchoredPosition, offscreen, duration);

  //   if (wrap)
  //   {
  //     // Instantly move to opposite side, offscreen
  //     Vector2 oppositeOffscreen = GetEdgePosition(offscreen: true, opposite: true);
  //     rectTransform.anchoredPosition = oppositeOffscreen;
  //   }
  // }

  public void SlideOn(float duration = 0.25f)
  {
    StopAllCoroutines();
    StartCoroutine(MoveToPosition(originalPosition));
  }

  // public IEnumerator SlideOnCoroutine(float duration = 0.25f)
  // {
  //   Vector2 flushEdge = GetEdgePosition(offscreen: false);
  //   yield return SlideTransform(rectTransform, rectTransform.anchoredPosition, flushEdge, duration);
  // }

  // private Vector2 GetEdgePosition(bool offscreen, bool opposite = false)
  // {
  //   if (canvasRect == null)
  //   {
  //     Debug.LogWarning("No canvas found for ImageSlider!");
  //     return rectTransform.anchoredPosition;
  //   }

  //   Vector2 currentPos = rectTransform.anchoredPosition;
  //   Vector2 dir = slideDirection.normalized;

  //   // If opposite, flip the direction
  //   if (opposite)
  //   {
  //     dir = -dir;
  //   }

  //   // Canvas bounds (assuming anchors at center)
  //   float canvasLeft = -canvasRect.rect.width / 2f;
  //   float canvasRight = canvasRect.rect.width / 2f;
  //   float canvasBottom = -canvasRect.rect.height / 2f;
  //   float canvasTop = canvasRect.rect.height / 2f;

  //   // Element bounds relative to its anchor position
  //   Rect elementRect = rectTransform.rect;
  //   float elementLeft = currentPos.x + elementRect.xMin;
  //   float elementRight = currentPos.x + elementRect.xMax;
  //   float elementBottom = currentPos.y + elementRect.yMin;
  //   float elementTop = currentPos.y + elementRect.yMax;

  //   // Calculate distance needed along the direction vector
  //   float distance = 0f;

  //   if (offscreen)
  //   {
  //     // Move until completely outside canvas
  //     if (dir.x > 0) // Moving right
  //       distance = (canvasRight - elementLeft) / dir.x;
  //     else if (dir.x < 0) // Moving left
  //       distance = (canvasLeft - elementRight) / dir.x;

  //     if (dir.y > 0) // Moving up
  //     {
  //       float distY = (canvasTop - elementBottom) / dir.y;
  //       distance = (distance == 0f) ? distY : Mathf.Max(distance, distY);
  //     }
  //     else if (dir.y < 0) // Moving down
  //     {
  //       float distY = (canvasBottom - elementTop) / dir.y;
  //       distance = (distance == 0f) ? distY : Mathf.Max(distance, distY);
  //     }
  //   }
  //   else
  //   {
  //     // Move until fully inside canvas (edge touching)
  //     if (dir.x > 0) // Moving right
  //       distance = (canvasRight - elementRight) / dir.x;
  //     else if (dir.x < 0) // Moving left
  //       distance = (canvasLeft - elementLeft) / dir.x;

  //     if (dir.y > 0) // Moving up
  //     {
  //       float distY = (canvasTop - elementTop) / dir.y;
  //       distance = (distance == 0f) ? distY : Mathf.Max(distance, distY);
  //     }
  //     else if (dir.y < 0) // Moving down
  //     {
  //       float distY = (canvasBottom - elementBottom) / dir.y;
  //       distance = (distance == 0f) ? distY : Mathf.Max(distance, distY);
  //     }
  //   }

  //   return currentPos + dir * distance;
  // }

  // public static IEnumerator SlideTransform(RectTransform rect, Vector2 from, Vector2 to, float duration)
  // {
  //   float t = 0f;
  //   while (t < duration)
  //   {
  //     t += Time.deltaTime;
  //     rect.anchoredPosition = Vector2.Lerp(from, to, t / duration);
  //     yield return null;
  //   }
  //   rect.anchoredPosition = to;
  // }
}