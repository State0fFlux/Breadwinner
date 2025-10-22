using UnityEngine;
public class SaltSinger : MonoBehaviour
{
  private AudioSource audioSrc;

  void OnEnable()
  {
    Actions.OnGhostAcquired += Sing;
  }
  void OnDisable()
  {
    Actions.OnGhostAcquired -= Sing;
  }

  void Start()
  {
    audioSrc = GetComponent<AudioSource>();
  }

  void Sing()
  {
    audioSrc.Play();
  }
}