using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectionMenu : MonoBehaviour
{

  [SerializeField] private TextMeshProUGUI namecard;
  [SerializeField] private TextMeshProUGUI bio;
  [SerializeField] private TextMeshProUGUI tagline;
  [SerializeField] private Image character;
  [SerializeField] private Image artifact;

  public int index;
  private int numCompanions;

  void Start()
  {
    numCompanions = InventoryData.Instance.Companions.Count;
    index = numCompanions - 1;
    UpdateCard();
  }

  public void Next()
  {
    index = (index + 1) % numCompanions;
    UpdateCard();
  }

  public void Prev()
  {
    index = (index - 1 + numCompanions) % numCompanions;
    UpdateCard();
  }

  private void UpdateCard()
  {
    CompanionData companion = InventoryData.Instance.Companions[index];
    namecard.text = companion.name + "\nRace: " + companion.type;
    bio.text = companion.biography;
    tagline.text = companion.tagline;
    character.sprite = companion.character;
    artifact.sprite = companion.collectibleIcon;
  }
}