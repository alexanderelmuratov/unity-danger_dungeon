using UnityEngine;

public class InputService : MonoBehaviour
{
    public Vector2 Direction { get; private set; }
    public Vector2 LookDirection { get; private set; }
    public bool InMove { get; private set; }
    public bool OnJump { get; private set; }
    public bool IsFirePressed { get; private set; }
    public bool IsFireHold { get; private set; }
    public bool IsFireReleased { get; private set; }

    private new Camera camera;

    private void Start()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        Direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        InMove = Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
        OnJump = Input.GetKeyDown(KeyCode.Space);
        IsFirePressed = Input.GetMouseButtonDown(0);
        IsFireHold = Input.GetMouseButton(0);
        IsFireReleased = Input.GetMouseButtonUp(0);

        var ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            var direction = (hitInfo.point - transform.position).normalized;
            LookDirection = new Vector2(direction.x, direction.z);
        }
    }
}
