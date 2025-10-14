using UnityEngine;
public class Door : MonoBehaviour
{
  [SerializeField] Transform doormat;

  public virtual void Exit()
  {
    Player.Instance.transform.position = doormat.position;
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
    {
      Enter();
    }
  }

  public virtual void Enter()
  {
    print("Try and exit the level!");
  }
}