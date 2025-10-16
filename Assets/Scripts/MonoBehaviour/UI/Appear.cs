using UnityEngine;

public class Appear : MonoBehaviour
{
    public float jumpHeight = 555f;
    public float bobHeight = 5f;
    
    public float bobSpeed = 0.47f;

    private RectTransform rectTransform;
    private Vector3 originalPosition;
    public bool appear;
    public bool scuffed;
    private float appearStartTime;

    private float oldY = 0;
    private float newY = 0;



    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition;
        appear = false;
        scuffed = true;
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && scuffed)
        {
            appear = true;
            appearStartTime = Time.time;
        }
        if (appear)
        {
            float elapsed = Time.time - appearStartTime;
            oldY = newY;
            newY = Mathf.Sin(elapsed * bobSpeed * Mathf.PI * 2) * jumpHeight;
            rectTransform.anchoredPosition = originalPosition + new Vector3(0, newY, 0);
            Debug.Log(newY + "-" + oldY + "=" + (newY - oldY));
            if (rectTransform.anchoredPosition.y >= 280 && rectTransform.anchoredPosition.y <= 290 && newY - oldY < -0.8)
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
