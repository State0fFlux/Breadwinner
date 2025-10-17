using UnityEngine;

[System.Serializable]
public struct DialogueLine
{
  public string speaker;
  [TextArea(6, 10)] public string text;
}

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue")]
public class DialogueData : ScriptableObject
{
  public DialogueLine[] lines;
}