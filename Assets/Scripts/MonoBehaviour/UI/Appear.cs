using UnityEngine;

public class Appear : MonoBehaviour
{
  public float jumpHeight = 666f;
  public float bobHeight = 10f;

  public float bobSpeed = 0.47f;

  private RectTransform rectTransform;
  private Vector3 originalPosition;
  public bool appear;
  public bool scuffed = true;
  public bool played;
  private float appearStartTime;

  private float oldY = 0;
  private float newY = 0;



  void Start()
  {
    rectTransform = GetComponent<RectTransform>();
    originalPosition = rectTransform.anchoredPosition;
    appear = false;
    scuffed = true;
    played = false;
  }
  void Update()
  {
    if (Menu.Instance.isDialogueMode && scuffed)
    {
      appear = true;
      appearStartTime = Time.time;
      scuffed = false;
    }
    if (appear)
    {
      if (!played)
      {
        GetComponent<AudioSource>().Play(0);
        played = true;
      }

      float elapsed = Time.time - appearStartTime;
      oldY = newY;
      newY = Mathf.Sin(elapsed * bobSpeed * Mathf.PI * 2) * jumpHeight;
      rectTransform.anchoredPosition = originalPosition + new Vector3(0, newY, 0);
      Debug.Log(newY + "-" + oldY + "=" + (newY - oldY));
      if (rectTransform.anchoredPosition.y >= 280 && rectTransform.anchoredPosition.y <= 290 && newY - oldY < -3)
      {
        appear = false;
        scuffed = false;
      }
    }
    else
    {
      float new2Y = Mathf.Sin(Time.time * bobSpeed * Mathf.PI * 2) * bobHeight;
      rectTransform.anchoredPosition = originalPosition + new Vector3(0, new2Y + newY, 0);
    }
  }
}