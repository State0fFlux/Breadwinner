using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

  public Animator transitionAnimator;
  public void GoToScene(string sceneName)
  {
    SceneManager.LoadScene(sceneName);
  }

  public void Quit()
  {
    Application.Quit();
    Debug.Log("It's Joever.");
  }

  public void ToggleActive(GameObject obj)
  {
    StartCoroutine(ToggleAfterAnimation(obj));
  }
  
  private IEnumerator ToggleAfterAnimation(GameObject obj)
{
    transitionAnimator.SetTrigger("Swoosh");
    yield return new WaitForSeconds(0.15f);
    obj.SetActive(!obj.activeSelf);
}

  public void Story()
    {
        Debug.Log("I need to do stuff here!");
    }
}
