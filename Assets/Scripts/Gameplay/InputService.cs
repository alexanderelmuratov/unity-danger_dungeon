using UnityEngine;

public class InputService : MonoBehaviour
{
    [SerializeField] private FloatingJoystick joystickPrefab;
    [SerializeField] private MobileButtonHandler jumpButtonPrefab;
    [SerializeField] private MobileButtonHandler fireButtonPrefab;
    private Transform mobileHandlerRoot;
    private FloatingJoystick joystick;
    private MobileButtonHandler jumpButton;
    private MobileButtonHandler fireButton;
    private new Camera camera;
    private bool isMobile;
    private float rotationSpeed = 10f;

    public Vector2 Direction { get; private set; }
    public Vector2 LookDirection { get; private set; }
    public bool InMove { get; private set; }
    public bool OnJump { get; private set; }
    public bool IsFirePressed { get; private set; }
    public bool IsFireHold { get; private set; }
    public bool IsFireReleased { get; private set; }

    private void Start()
    {
        isMobile = Application.isMobilePlatform;
        //isMobile = true;

        if (isMobile)
        {
            mobileHandlerRoot = GameObject.FindWithTag("MobileHandler").transform;
            joystick = Instantiate(joystickPrefab, mobileHandlerRoot);
            jumpButton = Instantiate(jumpButtonPrefab, mobileHandlerRoot);
            fireButton = Instantiate(fireButtonPrefab, mobileHandlerRoot);
        }
        else
            camera = Camera.main;
    }

    private void Update()
    {
        if (isMobile)
        {
            Direction = new Vector2(joystick.Horizontal, joystick.Vertical);
            InMove = joystick.Horizontal != 0 || joystick.Vertical != 0;
            OnJump = jumpButton.IsButtonPressed;
            IsFirePressed = fireButton.IsButtonPressed;
            IsFireHold = fireButton.IsButtonHold;
            IsFireReleased = fireButton.IsButtonReleased;

            jumpButton.IsButtonPressed = false;
            fireButton.IsButtonPressed = false;
            fireButton.IsButtonReleased = false;

            var direction = new Vector3(Direction.x, 0.0f, Direction.y);

            if (direction.magnitude > 0.1f)
            {
                Quaternion rotation = Quaternion.LookRotation(direction);
                rotation.x = 0;
                rotation.z = 0;
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
            }

            LookDirection = new Vector2(transform.forward.x, transform.forward.z).normalized;
        }
        else
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
}
