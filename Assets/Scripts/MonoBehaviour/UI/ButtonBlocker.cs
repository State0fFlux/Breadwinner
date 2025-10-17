using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonBlocker : MonoBehaviour
{
  protected Button button;
  protected virtual void OnEnable()
  {
    button = GetComponent<Button>();
    Refresh();
  }
  protected abstract bool ShouldBeEnabled();

  protected void Refresh()
  {
    bool should = ShouldBeEnabled();
    button.interactable = should;
    WiggleWiggle wig = button.GetComponent<WiggleWiggle>();
    if (wig)
    {
      wig.enabled = should;
    }
  }
}
