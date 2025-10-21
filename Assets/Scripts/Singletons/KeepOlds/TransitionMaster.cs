using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransitionMaster : KeepOldSingleton<TransitionMaster>
{

  //private Animator anim;
  public AudioSource sfx;
  public AudioSource music;
  public AudioClip companionFound;
  public Image sticker;

  private Animator anim;

  void OnEnable()
  {
    Actions.OnCompanionAcquired += ShowSticker;
  }
  void OnDisable()
  {
    Actions.OnCompanionAcquired -= ShowSticker;
  }

  protected override void Awake()
  {
    anim = GetComponentInChildren<Animator>();
    base.Awake();
    sfx = GetComponentInChildren<AudioSource>();
  }

  void ShowSticker(CompanionData data)
  {
    sfx.PlayOneShot(companionFound);
    sticker.sprite = data.stickerFound;
    anim.SetTrigger("ShowSticker");
  }

  public void SetMusic(AudioClip theme)
  {
    music.clip = theme;
    music.Play();
  }

  public void Transition(Action midway)
  {
    StartCoroutine(TransitionCoroutine(midway));
  }

  IEnumerator TransitionCoroutine(Action midway)
  {
    anim.SetTrigger("SwooshIn");

    // Wait until animator enters the state
    while (!anim.GetCurrentAnimatorStateInfo(0).IsName("SwooshIn"))
      yield return null;

    // Wait until animation finishes
    AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo(0);
    while (state.normalizedTime < 1f)
    {
      state = anim.GetCurrentAnimatorStateInfo(0);
      yield return null;
    }

    midway.Invoke();
    anim.SetTrigger("SwooshOut");
  }

  public void GoToScene(string sceneName)
  {
    sfx.Play();
    Transition(() => { SceneManager.LoadScene(sceneName); });
  }

}