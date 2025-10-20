using System.Linq;
using UnityEngine;

public class Story : MonoBehaviour
{
  [Header("Move out of way when starting story")]
  public ImageSlider[] clutter;
  public void StartStory()
  {
    // 1: move all buttons off to the side
    foreach (ImageSlider item in clutter)
    {
      item.SlideOff();
    }
    // 2: determine our next level judging by the ingredients we have
    // 3: run the dialogue scene for that level (fetch from scriptable object array somewhere?)
    // 4: open the next scene
  }
}