using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private string jumpSfxKey;
    [SerializeField] private float groundDistance = 1.1f;
    private Rigidbody rb;

    public Vector2 Direction { get; set; }
    public Vector2 LookDirection { get; set; } = Vector2.up;

    public void SetSpeed(float speed, float jumpSpeed)
    {
        this.speed = speed;
        this.jumpSpeed = jumpSpeed;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var move = new Vector3(Direction.x, 0f, Direction.y).normalized;

        if (rb.isKinematic)
            rb.MovePosition(transform.position + speed * Time.fixedDeltaTime * move);
        else
            rb.velocity = new Vector3(move.x * speed, rb.velocity.y, move.z * speed);

        transform.forward = new Vector3(LookDirection.x, 0, LookDirection.y);
    }

    public void Jump()
    {
        var isGrounded = Physics.Raycast(transform.position, Vector3.down, groundDistance);

        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            Context.Instance.AudioSystem.PlaySFX(new AudioSettings(jumpSfxKey, transform.position));
        }
    }
}
