using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public GameObject notif;
  public AudioClip theme;
  public Animator ani;

  void Start()
  {
    TransitionMaster.Instance.SetMusic(theme);
    notif.SetActive(Global.newCompanion);
  }

  public void GoToScene(string sceneName)
  {
    TransitionMaster.Instance.GoToScene(sceneName);
  }

  public void Quit()
  {
    TransitionMaster.Instance.sfx.Play();
    Application.Quit();
    Debug.Log("It's Joever.");
  }

  public void ToggleActive(GameObject obj)
  {
    TransitionMaster.Instance.sfx.Play();
    ani.SetTrigger("Swoosh");
    obj.SetActive(!obj.activeSelf);
    // TransitionMaster.Instance.Transition(() => {  });
  }

  public void DisableNotif()
  {
    Global.newCompanion = false;
    notif.SetActive(false);
  }
}