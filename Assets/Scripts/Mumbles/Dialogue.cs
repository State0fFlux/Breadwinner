using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
  public TextMeshProUGUI textComponent;

  // public string[] starting = new string[] {
  //     " ",
  //     " ",
  //     "This should play at the start",
  //     "Test message 1",
  //     "Test message 2",
  //     "LONG LONG LONG LONG LONG LONG LONG LONG LONG TESSSST MESSAGE",
  //     "I NEED bread.",
  //     "I need bread baaaaaaaad."
  // };
  string[] starting = new string[] {
        "Hello, everyone!",
        "Welcome to my bakery, I'm so happy to have all of you here!",
        "Today, we'll be making some delicious bread and we really knead to get a move on!",
        "I've already gotten the flour and water, so the next thing we need is some yeast!",
        "Let's go, my sous-chef!"
    };
  string[] a_yeast_y_friend = new string[] {
        "Yay, we got the yeast! And a new friend! Wasn't she beautiful?",
        "Now, we have another friend to share our bread with!",
        "We're on a roll, haha!",
        "Next up, we should get some salt. I can't seem to remember where I put it though...",
        "Hopefully, we can rise to the challenge and find it together!"
    };

  string[] a_yeast_n_friend = new string[] {
        "Yay, we got the yeast!",
        "We're on a roll, haha!",
        "Next up, we should get some salt. I can't seem to remember where I put it though...",
        "Hopefully, we can rise to the challenge and find it together!"
    };

  string[] a_salt_y_friend = new string[] {
        "Wow… we really need to fix those doors, haha!",
        "But at least we got the salt, thanks to you and Brine!",
        "I'm sure they'll love the bread too! Let's not keep them waiting, okay?",
        "No more loafing around! We've got a bread to bake!"
    };

  string[] a_salt_n_friend = new string[] {
        "Wow… we really need to fix those doors, haha!",
        "But at least we got the salt!",
        "I think that's everything we need, which means no more loafing around!",
        "We've got a bread to bake!"
    };

  private string[] lines;
  private string scene;
  public float textSpeed;
  public Story story;

  public int index = 0;

  // Start is called before the first frame update
  void Start()
  {
    index = 0;
    textComponent.text = string.Empty;
    if (!InventoryData.Instance.Has(IngredientData.Type.Yeast)) // need yeast
    {
      scene = "Dark Room";
      lines = starting;
    }
    else if (!InventoryData.Instance.Has(IngredientData.Type.Salt)) // need salt
    {
      scene = "Salt Room";
      if (InventoryData.Instance.Has(CompanionData.Type.Fairy))
      {
        lines = a_yeast_y_friend;
      }
      else
      {
        lines = a_yeast_n_friend;
      }
    }
    else // enter endgame (NOTE: in the future we will want to require flour before salt)
    {
      scene = "Ending";
      if (InventoryData.Instance.Has(CompanionData.Type.Ghost))
      {
        lines = a_salt_y_friend;
      }
      else
      {
        lines = a_salt_n_friend;
      }
    }
    StartDialogue();
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      if (textComponent.text == lines[index])
      {
        NextLine();
      }
      else
      {
        StopAllCoroutines();
        textComponent.text = lines[index];
      }
    }
  }

  void StartDialogue()
  {
    index = 0;
    StartCoroutine(TypeLine());
  }

  IEnumerator TypeLine()
  {
    foreach (char c in lines[index].ToCharArray())
    {
      textComponent.text += c;
      yield return new WaitForSeconds(textSpeed);
    }
  }

  void NextLine()
  {
    if (index < lines.Length - 1)
    {
      index++;
      textComponent.text = string.Empty;
      StartCoroutine(TypeLine());
    }
    else
    {
      // checklist.SetActive(true);
      story.EndStory();
      TransitionMaster.Instance.GoToScene(scene);
    }
  }
}