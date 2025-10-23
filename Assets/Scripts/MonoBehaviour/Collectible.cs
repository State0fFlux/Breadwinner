using UnityEngine;

public abstract class Collectible<T> : MonoBehaviour
{
  public T data;
  public AudioClip collectionSFX;

  void OnTriggerEnter2D(Collider2D other)
  {
    if (!other.CompareTag("Player")) return;
    AddToInventory(data);
    TransitionMaster.Instance.sfx.PlayOneShot(collectionSFX, 2f);
    Destroy(gameObject);
  }

  protected abstract void AddToInventory(T data);
}
