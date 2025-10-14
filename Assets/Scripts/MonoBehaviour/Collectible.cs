using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Collectible : MonoBehaviour
{
  public CollectibleData data; // assign IngredientData or CompanionData in Inspector

  void OnTriggerEnter2D(Collider2D other)
  {
    if (!other.CompareTag("Player")) return;
    Player player = other.gameObject.GetComponent<Player>();
    Inventory inv = player.inventory;

    // Call the right inventory method based on actual type
    switch (data)
    {
      case IngredientData ingredient:
        inv.AddIngredient(ingredient);
        break;
      case CompanionData companion:
        inv.AddCompanion(companion);
        break;
      default:
        Debug.LogError($"Unrecognized collectible type: {data.GetType()}");
        break;
    }

    Destroy(gameObject);
  }
}
