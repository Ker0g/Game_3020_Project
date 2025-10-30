using UnityEngine;
using UnityEngine.InputSystem;
public class WheelSpin : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 200f;
    [SerializeField] private float maxRotation = 45f;
    private float currentRotation = 0f;
   
    [SerializeField] InputActionAsset playerActionMap;

    InputAction moveAction;

    public Vector2 direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = playerActionMap.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        direction = moveAction.ReadValue<Vector2>();

        currentRotation += direction.x * rotationSpeed * Time.deltaTime;
        currentRotation = Mathf.Clamp(currentRotation, -maxRotation, maxRotation);

        if (direction.x == 0f)
            currentRotation = Mathf.Lerp(currentRotation, 0f, Time.deltaTime * 2f);

        transform.rotation = Quaternion.Euler(0f, 0f, -currentRotation);
    }
}
