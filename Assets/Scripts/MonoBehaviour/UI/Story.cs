using System.Linq;
using UnityEngine;

public class Story : MonoBehaviour
{
  [Header("Move out of way when starting story")]
  public ImageSlider[] clutter;
  public ImageSlider dialogbox;
  public GameObject dialogueBox;
  public GameObject crust;
  public void StartStory()
  {
    Menu.Instance.isDialogueMode = true;
    // 1: move all buttons off to the side
    foreach (ImageSlider item in clutter)
    {
      item.SlideOff();
    }
    crust.GetComponent<Animator>().SetTrigger("Appear");
    crust.GetComponent<AudioSource>().Play();
    dialogueBox.SetActive(true);
    dialogbox.SlideOff();
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