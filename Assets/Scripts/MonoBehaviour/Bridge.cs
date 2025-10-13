using UnityEngine;

public class Bridge : MonoBehaviour
{

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.layer == Global.playerLayer)
    {
      Player.bridgesPlayerIsOn++;

      // Disable wall collision if this is the first bridge
      if (Player.bridgesPlayerIsOn == 1)
      {
        Physics2D.IgnoreLayerCollision(Global.playerLayer, Global.wallLayer, true);
      }
    }
  }

  void OnTriggerExit2D(Collider2D other)
  {
    if (other.gameObject.layer == Global.playerLayer)
    {
      Player.bridgesPlayerIsOn = Mathf.Max(0, Player.bridgesPlayerIsOn - 1);

      // Only re-enable collisions when no bridges remain
      if (Player.bridgesPlayerIsOn == 0)
      {
        Physics2D.IgnoreLayerCollision(Global.playerLayer, Global.wallLayer, false);
      }
    }
  }
}
