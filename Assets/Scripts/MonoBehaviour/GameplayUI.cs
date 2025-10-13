using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour
{
  [SerializeField] Slider ingredientSlider;
  [SerializeField] TextMeshProUGUI companionsText;

  void Awake()
  {
    Inventory.Instance.OnInventoryChanged += UpdateInventoryUI;
  }

  void Start()
  {
    UpdateInventoryUI();
  }

  void UpdateInventoryUI()
  {
    // Handle ingredients
    IngredientData type = MazeMaster.Instance.GetCurrentObjective();
    float percentage = Inventory.GetPercentage(type);
    ingredientSlider.value = percentage;

    companionsText.text = "Companions:\n";
    // Handle companions
    foreach (CompanionData companion in Inventory.GetCompanions())
    {
      companionsText.text += $"{companion.type}\n";
    }
  }
}