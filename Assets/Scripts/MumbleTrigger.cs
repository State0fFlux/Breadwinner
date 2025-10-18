using UnityEngine;

public class MumbleTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<MumbleGenerator.MumblePlayer>().PlayMumble();
        // MumbleGenerator.MumblePlayer mp = GetComponent<MumbleGenerator.MumblePlayer>();
        // mp.PlayMumble();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
