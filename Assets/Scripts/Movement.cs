using Unity.VisualScripting;
using UnityEditor.Callbacks;
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
    Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    Move(input);
  }

  protected virtual void Move(Vector2 input)
  {
    rb.AddForce(input);
  }
}

public class IceMovement : Movement
{
    private bool isSliding = false;
    private Vector2 slideDirection;

    protected override void Move(Vector2 input)
    {
        // If we're currently sliding, ignore new input
        if (isSliding)
            return;

        // If input given, start sliding
        if (input != Vector2.zero)
        {
            isSliding = true;
            slideDirection = input.normalized;
        }
    }

    void Update()
    {
        if (isSliding)
        {
            // Move in the slide direction continuously
            rb.linearVelocity = slideDirection;

            // Check if we hit a wall (stopped)
            if (rb.linearVelocity.magnitude < 0.1f)
            {
                isSliding = false;
                rb.linearVelocity = Vector2.zero;
            }
        }
        else
        {
            // Not sliding, stop all motion
            rb.linearVelocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Hitting a wall stops sliding
        isSliding = false;
        rb.linearVelocity = Vector2.zero;
    }
}

