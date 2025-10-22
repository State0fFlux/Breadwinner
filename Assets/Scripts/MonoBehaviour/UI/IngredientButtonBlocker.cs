using UnityEngine;
using UnityEngine.UI;

public class IngredientButtonBlocker : ButtonBlocker
{
  [Header("You must have this ingredient to activate this button")]
  [SerializeField] private IngredientData.Type ingredient;

  [Header("What the 'filled' version of this button looks like")]
  [SerializeField] private Sprite filled;
  protected override bool ShouldBeEnabled()
      => InventoryData.Instance.Has(ingredient);

  void Start()
  {
    if (button.interactable)
    {
      GetComponent<Image>().sprite = filled;
    }
  }
}
