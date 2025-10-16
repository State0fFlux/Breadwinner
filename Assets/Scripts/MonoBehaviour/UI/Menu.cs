using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public struct SubMenu
{
  public GameObject button;
  public GameObject panel;
}

public class Menu : MonoBehaviour
{
  [Header("Could prob handle this better lol, but this works")]
  [SerializeField] private SubMenu[] subMenus;

  public void GoToScene(string sceneName)
  {
    SceneManager.LoadScene(sceneName);
  }

  public void Quit()
  {
    Application.Quit();
    Debug.Log("It's Joever.");
  }

  public void Story()
  {
    Debug.Log("I need to do stuff here!");
  }

  /// <summary>
  /// Turns off all other submenus, then toggles the specified subpanel
  /// </summary>
  /// <param name="panel">the panel whose submenu you wish to toggle</param>
  public void ToggleSubMenu(GameObject panel)
  {
    bool activating = !panel.activeSelf;
    foreach (SubMenu submenu in subMenus)
    {
      if (submenu.panel == panel) // this is the submenu we want to toggle!
      {
        ToggleActive(submenu.panel);
        submenu.button.SetActive(true); // we want this button to be active regardless
      }
      else // this is one of the other submenus
      {
        submenu.panel.SetActive(false);
        submenu.button.SetActive(!activating);
      }
    }
  }

  private void ToggleActive(GameObject obj)
  {
    obj.SetActive(!obj.activeSelf);
  }
}
