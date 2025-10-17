using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

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
    obj.SetActive(!obj.activeSelf);
  }

  public void Story()
  {
    Debug.Log("I need to do stuff here!");
  }
}
