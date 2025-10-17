using UnityEngine;
public class LevelMaster : KeepNewSingleton<LevelMaster>
{
  public Door levelStart;
  public LevelData data;

  private AudioSource audioSrc;

  void Awake()
  {
    audioSrc = GetComponent<AudioSource>();
    print(audioSrc);
  }

  void Start()
  {
    audioSrc.clip = data.theme;
    audioSrc.Play();
    levelStart.Exit();
  }
}