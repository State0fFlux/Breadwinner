using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCompanion", menuName = "Collectible/Companion")]
public class CompanionData : CollectibleData
{
  public enum Type
  {
    Fairy,
    Cat,
    Ghost
  }

  public Sprite character;
  public new string name = "What is my name?";
  public string tagline = "Give me a tagline!";

  [TextArea(4, 10)] public string biography = "Add a bio!";

  public Type type;
  public AudioClip theme;
  public override string ToString()
  {
    return Global.FormatEnumName(type);
  }
}