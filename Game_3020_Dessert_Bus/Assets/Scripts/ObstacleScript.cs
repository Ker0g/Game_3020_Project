using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    [SerializeField] int moveSpeed = 1;
    [SerializeField] int damage = 1;
    [SerializeField] float lifetime = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

        Destroy(gameObject, lifetime);
    }
}
