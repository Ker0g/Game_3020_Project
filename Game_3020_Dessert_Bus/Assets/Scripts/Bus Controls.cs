using UnityEngine;
using UnityEngine.InputSystem;

public class BusControls : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] InputActionAsset playerActionMap;
    [SerializeField] int speed;

    
    [SerializeField] Boundary horizontalBoundry;

    InputAction moveAction;

    Vector2 direction;

    void Start()
    {
        moveAction = playerActionMap.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        direction = moveAction.ReadValue<Vector2>();

        Vector2 movement = direction * speed * Time.deltaTime;

        transform.position = new Vector3(transform.position.x + movement.x, transform.position.y + movement.y, transform.position.z);

        CheckBoundaries();
    }

    void CheckBoundaries()
    {
        float positionX = Mathf.Clamp(transform.position.x, horizontalBoundry.min, horizontalBoundry.max);
        

        transform.position = new Vector3(positionX, transform.position.y, transform.position.z);
    }

}