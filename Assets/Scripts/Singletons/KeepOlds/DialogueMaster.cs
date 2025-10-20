using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueMaster : KeepOldSingleton<DialogueMaster>
{
  public DialogueData[] dialogues;
  private int index = 0;
  public GameObject node;
  public Sprite a;
  public Sprite b;
  private Image img;

  private bool isRotating = false;

  void Start()
  {
    img = node.GetComponent<Image>();
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.R))
    {
      StartCoroutine(SwapSprite());
    }
  }

  IEnumerator SwapSprite()
  {
    yield return RotateSprite(90f);
    if (img.sprite == a)
    {
      img.sprite = b;
    }
    else
    {
      img.sprite = a;
    }
    yield return RotateSprite(90f);
  }

  IEnumerator RotateSprite(float change)
  {
    float startY = node.transform.eulerAngles.y;
    float endY = startY + change;

    yield return Global.AnimateFloat(
        start: startY,
        end: endY,
        onUpdate: value =>
        {
          Vector3 euler = node.transform.eulerAngles;
          euler.y = value;
          node.transform.eulerAngles = euler;
        },
        duration: 1f
    );
  }

  public void RunDialogue()
  {
    // Placeholder for dialogue logic
  }
}
