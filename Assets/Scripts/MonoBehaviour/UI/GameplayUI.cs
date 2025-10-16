using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour
{
  [SerializeField] Slider ingredientSlider;
  [SerializeField] TextMeshProUGUI companionsText;

  void OnEnable() => Inventory.Instance.OnInventoryChanged += UpdateInventoryUI;
  void OnDisable() => Inventory.Instance.OnInventoryChanged -= UpdateInventoryUI;


  void Start()
  {
    UpdateInventoryUI();
  }

  void UpdateInventoryUI()
  {
    // Handle ingredients
    IngredientData type = MazeMaster.Instance.GetCurrentObjective();
    float percentage = Inventory.Instance.GetPercentage(type);
    ingredientSlider.value = percentage;

    companionsText.text = "Companions:\n";
    // Handle companions
    foreach (CompanionData companion in Inventory.Instance.GetCompanions())
    {
      companionsText.text += $"{companion.type}\n";
    }
  }
}