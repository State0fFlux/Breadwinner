using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class RecipeEntry : MonoBehaviour
{
  public IngredientData ingredient;
  public Image slash;

  private TextMeshProUGUI text;

  void Start()
  {
    text = GetComponent<TextMeshProUGUI>();
    text.text = ingredient.ToString().ToLower();
    slash.enabled = Inventory.Instance.GetPercentage(ingredient) == 1;
  }
}