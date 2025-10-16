using UnityEngine;

public class Appear : MonoBehaviour
{
    public SpriteRenderer spriteToShow;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spriteToShow.enabled = !spriteToShow.enabled;
        }
    }
}
