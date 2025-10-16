using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class Movement : MonoBehaviour // standard WASD
{
  protected Rigidbody2D rb;

  public static Movement Instance;

  void OnEnable()
  {
    if (Instance != null && Instance != this)
    {
      Destroy(Instance.gameObject);
    }
    Instance = this;
  }
  void OnDisable()
  {
    Instance = null;
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
    rb.linearVelocity = input * PlayerData.Instance.speed;
  }
}

