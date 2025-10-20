using UnityEngine;
using UnityEngine.UI;

public class CollectibleBox : MonoBehaviour
{
  public CompanionData.Type type;
  private Image image;

  void OnEnable()
  {
    Actions.OnCompanionAcquired += UpdateBox;
  }

  void OnDisable()
  {
    Actions.OnCompanionAcquired -= UpdateBox;
  }

  void Awake()
  {
    image = GetComponent<Image>();
  }

  void Start()
  {
    UpdateBox();
  }

  void UpdateBox(CompanionData data)
  {
    if (data.type == type)
    {
      image.sprite = data.collectibleIcon;
    }
  }

  // Pull from inventory
  void UpdateBox()
  {
    foreach (CompanionData companion in InventoryData.Instance.Companions)
    {
      if (companion.type == type)
      {
        image.sprite = companion.collectibleIcon;
      }
    }
  }
}