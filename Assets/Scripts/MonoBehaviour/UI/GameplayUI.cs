using UnityEngine;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour
{
  [SerializeField] Slider ingredientSlider;

  void OnEnable() => InventoryData.Instance.OnInventoryChanged += UpdateInventoryUI;
  void OnDisable() => InventoryData.Instance.OnInventoryChanged -= UpdateInventoryUI;

  void Start()
  {
    UpdateInventoryUI();
  }

  void UpdateInventoryUI()
  {
    // Handle ingredients
    IngredientData type = LevelMaster.Instance.data.ingredientGoal;
    float percentage = InventoryData.Instance.GetPercentage(type);
    ingredientSlider.value = percentage;
  }
}