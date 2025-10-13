using UnityEngine;
using UnityEngine.Rendering.Universal;

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
        Inventory.AddIngredient(ingredient);
        break;
      case CompanionData companion:
        // TODO: make this more modular if we add more companion types
        switch (companion.type)
        {
          case CompanionData.Type.Fairy:
            // Play fairy collection SFX
            Player.Instance.UpdateLantern(transform.Find("Light").gameObject);
            break;
        }
        Inventory.AddCompanion(companion);
        break;
      default:
        Debug.LogError($"Unrecognized collectible type: {data.GetType()}");
        break;
    }

    Destroy(gameObject);
  }
}
