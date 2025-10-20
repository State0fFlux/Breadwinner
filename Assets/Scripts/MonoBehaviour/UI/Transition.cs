using UnityEngine;
using UnityEngine;
public class Transition : MonoBehaviour
{
    private Vector3 originalPosition;
    public Vector3 offscreenOffset = new Vector3(0, -1000, 0);  // Move off screen downward
    public float moveDuration = 0.5f;

    private void Start()
    {
        originalPosition = transform.localPosition;
    }

    public void AnimateOffScreen()
    {
        StopAllCoroutines();
        StartCoroutine(MoveToPosition(originalPosition + offscreenOffset));
    }

    public void AnimateOnScreen()
    {
        StopAllCoroutines();
        StartCoroutine(MoveToPosition(originalPosition));
    }

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

}
