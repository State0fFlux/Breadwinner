using UnityEngine;
using UnityEngine.UI;

public class IngredientButtonBlocker : ButtonBlocker
{
  [Header("You must have this ingredient to activate this button")]
  [SerializeField] private IngredientData.Type ingredient;
  protected override bool ShouldBeEnabled()
      => InventoryData.Instance.Has(ingredient);
}
