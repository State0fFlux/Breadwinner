using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class Movement : MonoBehaviour // standard WASD
{
  protected Rigidbody2D rb;
  [SerializeField] int speed = 2;

  public static Movement Instance; // Singleton

  void Awake()
  {
    if (Instance != null && Instance != this)
    {
      Destroy(Instance.gameObject);
    }
    else
    {
      Instance = this;
    }
  }

  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  void Update()
  {
    Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
    Move(input);
  }

  protected virtual void Move(Vector2 input)
  {
    //rb.AddForce(input * speed);
    rb.linearVelocity = input * speed;
  }

  public void SetSpeed(int newSpeed)
  {
    speed = newSpeed;
  }
}

