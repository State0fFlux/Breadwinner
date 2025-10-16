using UnityEngine;

public class Movement : MonoBehaviour // standard WASD
{
  protected Rigidbody2D rb;

  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  void Update()
  {
    Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
    Move(input);
  }

  void Move(Vector2 input)
  {
    //rb.AddForce(input * speed);
    rb.linearVelocity = input * PlayerData.Instance.speed;
  }
}

