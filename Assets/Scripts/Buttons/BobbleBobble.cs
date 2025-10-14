using UnityEngine;

public class BobbleBobble : MonoBehaviour
{
    public float bobHeight = 10f;
    public float bobSpeed = 2f;

    private RectTransform rectTransform;
    private Vector3 originalPosition;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition;
    }

    void Update()
    {
        float newY = Mathf.Sin(Time.time * bobSpeed * Mathf.PI * 2) * bobHeight;
        rectTransform.anchoredPosition = originalPosition + new Vector3(0, newY, 0);
    }
}