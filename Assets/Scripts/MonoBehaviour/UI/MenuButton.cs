// TODO: DELETE THIS! This is only used for debugging purposes in levels

using UnityEditorInternal;
using UnityEngine;
public class MenuButton : MonoBehaviour
{
  public void Menu()
  {
    TransitionMaster.Instance.GoToScene("Main Menu");
  }
}