using UnityEngine;

public class Movement : MonoBehaviour // standard WASD
{
  private Rigidbody2D rb;
  private Vector2 currDirection = Vector2.zero;
  private Vector2 prevInput = Vector2.zero;
  private Vector2 currInput = Vector2.zero;

  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  void Update()
  {
    currInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    if (currInput != prevInput)
    {
      currDirection = currInput;
    }
    prevInput = currInput;
  }

  void FixedUpdate()
  {
    Move();
  }

  void Move()
  {
    //rb.AddForce(input * speed);
    rb.linearVelocity = currDirection * Player.Instance.speed;
  }

  // External method to set direction (e.g., from portal)
  public void SetDirection(Vector2 direction)
  {
    if (direction != Vector2.zero)
      currDirection = direction.normalized;
  }
}

