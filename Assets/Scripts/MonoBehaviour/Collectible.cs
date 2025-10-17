using UnityEngine;

public abstract class Collectible<T> : MonoBehaviour
{
  public T data;

  void OnTriggerEnter2D(Collider2D other)
  {
    if (!other.CompareTag("Player")) return;
    AddToInventory(data);
    Destroy(gameObject);
  }

  protected abstract void AddToInventory(T data);
}
