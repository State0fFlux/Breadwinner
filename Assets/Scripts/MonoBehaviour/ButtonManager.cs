using UnityEngine;
public class ButtonManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] buttonClicks;

    public void PlayRandButtonNoise()
    {
        GetComponent<AudioSource>().PlayOneShot(buttonClicks[Random.Range(0, buttonClicks.Length)]);
    }

    public void Play()
    {
        PlayRandButtonNoise();
        SceneTransitionManager.Instance.TransitionToGame();
    }

    public void Lobby()
    {
        PlayRandButtonNoise();
        SceneTransitionManager.Instance.TransitionToLobby();
    }

    public void Quit()
    {
        PlayRandButtonNoise();
        SceneTransitionManager.Instance.Quit();
    }
}
