using UnityEngine;

public abstract class Collectible<T> : MonoBehaviour
{
  public T data;
  public AudioClip collectionSFX;
  private AudioSource audioSrc;

  void Start()
  {
    audioSrc = GetComponent<AudioSource>();
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (!other.CompareTag("Player")) return;
    AddToInventory(data);
    audioSrc.PlayOneShot(collectionSFX);
    Destroy(gameObject);
  }

  protected abstract void AddToInventory(T data);
}
