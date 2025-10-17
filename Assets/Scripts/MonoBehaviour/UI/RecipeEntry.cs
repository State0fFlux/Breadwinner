using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class RecipeEntry : MonoBehaviour
{
  public IngredientData ingredient;
  public Image slash;

  private TextMeshProUGUI text;

  void Awake()
  {
    text = GetComponent<TextMeshProUGUI>();
    text.text = ingredient.ToString().ToLower();
    slash.enabled = InventoryData.Instance.GetPercentage(ingredient) == 1;
  }
}