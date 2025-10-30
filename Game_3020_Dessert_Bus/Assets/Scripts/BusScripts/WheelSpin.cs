using UnityEngine;
using UnityEngine.InputSystem;
public class WheelSpin : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 200f;
    [SerializeField] private float maxRotation = 45f;
    private float currentRotation = 0f;
    private float steeringInput = 0f;

    [SerializeField] InputActionAsset playerActionMap;

    InputAction moveAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = playerActionMap.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
