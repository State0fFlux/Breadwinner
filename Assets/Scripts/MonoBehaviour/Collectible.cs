using UnityEngine;

public class Collectible : MonoBehaviour
{
  public CollectibleData data; // assign IngredientData or CompanionData in Inspector

  void OnTriggerEnter2D(Collider2D other)
  {
    if (!other.CompareTag("Player")) return;

    // Call the right inventory method based on actual type
    switch (data)
    {
      case IngredientData ingredient:
        Inventory.Instance.AddIngredient(ingredient);
        break;
      case CompanionData companion:
        Inventory.Instance.AddCompanion(companion);
        break;
      default:
        Debug.LogError($"Unrecognized collectible type: {data.GetType()}");
        break;
    }

    Destroy(gameObject);
  }
}
