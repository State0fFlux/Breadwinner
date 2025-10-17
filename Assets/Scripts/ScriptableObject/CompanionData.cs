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

  public new string name;
  public string tagline;

  [TextArea(4, 10)] public string biography;

  public Type type;
  public AudioClip theme;
  public override string ToString()
  {
    return Global.FormatEnumName(type);
  }
}