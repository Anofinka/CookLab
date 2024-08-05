using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class BasePlayerController : MonoBehaviour
{
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected float speed = 5f;

    protected Vector3 input;
    protected Controls controls;
    protected bool isRolling = false;

    protected abstract InputActionMap GetInputActionMap();
    protected abstract void SetCallbacks();

    private void Awake()
    {
        controls = new Controls();
        SetCallbacks();
    }

    private void OnEnable()
    {
        GetInputActionMap().Enable();
    }

    private void OnDisable()
    {
        GetInputActionMap().Disable();
    }

    protected virtual void Update()
    {
        // Opcjonalnie mo¿na dodaæ dodatkow¹ logikê w Update()
    }

    private void FixedUpdate()
    {
        if (!isRolling)
        {
            Move();
        }
    }

    private void Move()
    {
        if (input != Vector3.zero)
        {
            // Przekszta³canie wejœcia w kierunek lokalny obiektu
            Vector3 moveDirection = Helpers.ToIso(input);
            rb.MovePosition(transform.position + moveDirection * speed * Time.deltaTime);
        }
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        Vector2 inputVector = context.ReadValue<Vector2>();
        input = new Vector3(inputVector.x, 0, inputVector.y);
    }
}

public static class Helpers
{
    private static Matrix4x4 isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));

    public static Vector3 ToIso(Vector3 input)
    {
        return isoMatrix.MultiplyPoint3x4(input);
    }
}
