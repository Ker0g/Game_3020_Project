using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class BusControls : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] InputActionAsset playerActionMap;
    [SerializeField] int speed;
    [SerializeField] float correctionTime;
    Rigidbody2D rb;

    float timer = 1f;
    
    [SerializeField] Boundary horizontalBoundry;

    InputAction moveAction;

    public Vector2 direction;

    void Start()
    {
        SoundManager.PlayMusic("boundless-blue");
        rb = GetComponent<Rigidbody2D>();
        moveAction = playerActionMap.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            StuffManager.Instance.PassTime();
        }
        
        direction = moveAction.ReadValue<Vector2>();
        if (direction.x != 0)
        {
            rb.AddForce(Vector2.right * direction.x * speed);
        }
        else
        {
            rb.linearVelocityX = Mathf.Lerp(rb.linearVelocityX, 0, Time.deltaTime * 2);
        }
            //Vector2 movement = direction * speed * Time.deltaTime;

            //transform.position = new Vector3(transform.position.x + movement.x, transform.position.y + movement.y, transform.position.z);

            CheckBoundaries();

        if(StuffManager.Instance.ApprovalRating <= 0)
        {
            SceneManager.LoadScene("EndScene");
        }
    }

    void CheckBoundaries()
    {
        float positionX = Mathf.Clamp(transform.position.x, horizontalBoundry.min, horizontalBoundry.max);
        

        transform.position = new Vector3(positionX, transform.position.y, transform.position.z);
    }

}