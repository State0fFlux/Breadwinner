using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

  public Animator transitionAnimator;
  public int game_state = 0;

  public bool isDialogueMode = false;
  public GameObject dialogueBox;

  public static Menu Instance { get; private set; }

  private void Awake()
  {
    if (Instance != null && Instance != this)
    {
      Destroy(gameObject);
    }
    else
    {
      Instance = this;
    }
  }

  // THIS IS CODE FOR GARY'S TRANSITION CLASS
  /*
  public void ToggleMode()
  {
    isDialogueMode = !isDialogueMode;

    if (isDialogueMode)
    {
      foreach (var btn in buttonsToHide)
        btn.AnimateOffScreen();

      dialogueBox.SetActive(true);
    }
    else
    {
      foreach (var btn in buttonsToHide)
        btn.AnimateOnScreen();

      dialogueBox.SetActive(false);
    }
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
    ToggleMode();
    // Only based on ingredients and not companions so far
    switch (game_state)
    {
      case 0: // No ingredients (start of game)

        break;
      case 1: // 1 ingredient

        break;
      case 2: // 2 ingredients

        break;
      case 3: // 3 ingredients

        break;
      default:
        break;
    }
  }
  */

  public void GoToScene(string sceneName)
  {
    SceneManager.LoadScene(sceneName);
  }

  public void Exit()
  {
    Application.Quit();
    Debug.Log("It's Joever.");
  }
}
