using UnityEngine;
public class Door : MonoBehaviour
{
  [SerializeField] Transform doormat;

  public virtual void Exit()
  {
    Player.Instance.transform.position = doormat.position;
    Vector2 direction = (doormat.position - transform.position).normalized;
    Player.Instance.Movement.SetDirection(direction);
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