using UnityEngine;

public class MainMenu : MonoBehaviour
{
  public GameObject exclamation;
  void Start()
  {
    exclamation.SetActive(Global.newCompanion);
  }

  public void OpenCollections()
  {
    Global.newCompanion = false;
    exclamation.SetActive(false);
  }
}