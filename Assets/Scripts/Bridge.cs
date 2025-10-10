using UnityEngine;

public class Bridge : MonoBehaviour
{
    // Track how many bridges the player is currently on
    private static int bridgesPlayerIsOn = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == Global.playerLayer)
        {
            bridgesPlayerIsOn++;

            // Disable wall collision if this is the first bridge
            if (bridgesPlayerIsOn == 1)
            {
                Physics2D.IgnoreLayerCollision(Global.playerLayer, Global.wallLayer, true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == Global.playerLayer)
        {
            bridgesPlayerIsOn = Mathf.Max(0, bridgesPlayerIsOn - 1);

            // Only re-enable collisions when no bridges remain
            if (bridgesPlayerIsOn == 0)
            {
                Physics2D.IgnoreLayerCollision(Global.playerLayer, Global.wallLayer, false);
            }
        }
    }
}
