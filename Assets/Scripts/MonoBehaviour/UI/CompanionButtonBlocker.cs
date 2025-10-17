using UnityEngine;
using UnityEngine.UI;

public class CompanionButtonBlocker : ButtonBlocker
{
  [Header("You must have at least this many companions to activate this button")]
  [SerializeField] private int min;
  protected override bool ShouldBeEnabled()
    => InventoryData.Instance.Companions.Count >= min;
}
