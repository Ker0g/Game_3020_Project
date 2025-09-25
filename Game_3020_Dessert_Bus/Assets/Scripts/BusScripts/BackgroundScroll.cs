using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] float speed;
    [SerializeField] float upperBoarder, lowerBoarder;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = transform.position + Vector3.down * Time.deltaTime;
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < lowerBoarder)
        {
            transform.position = new Vector3(transform.position.x, upperBoarder, transform.position.z);
        }
    }
}