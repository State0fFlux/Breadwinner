using UnityEngine;

[CreateAssetMenu(fileName = "NewLevel", menuName = "Level")]
public class LevelData : ScriptableObject
{
  public AudioClip theme;
  public IngredientData ingredientGoal;
  public CompanionData companionGoal;
}