using System.Linq;
using UnityEngine;

public class Story : MonoBehaviour
{
  [Header("Move out of way when starting story")]
  public ImageSlider[] clutter;
  public ImageSlider dialogbox;
  public GameObject dialogueBox;
  public void StartStory()
  {
    Menu.Instance.isDialogueMode = true;
    // 1: move all buttons off to the side
    foreach (ImageSlider item in clutter)
    {
      item.SlideOff();
    }
    dialogueBox.SetActive(true);
    dialogbox.SlideOn();
    // 2: determine our next level judging by the ingredients we have
    // 3: run the dialogue scene for that level (fetch from scriptable object array somewhere?)
    // 4: open the next scene
  }

  public void EndStory()
  {
    foreach (ImageSlider item in clutter)
    {
      item.SlideOn();
    }
    dialogbox.SlideOff();
    dialogueBox.SetActive(false);
  }
}