using UnityEngine;

public class RockSpawner : MonoBehaviour
{

    [SerializeField] GameObject rockPrefab;
    [SerializeField] float spawnInterval = 2f;
    [SerializeField] float resetTime = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnInterval -= Time.deltaTime;

        if (spawnInterval <= 0f)
        {
            SpawnRock();
            spawnInterval = resetTime;
        }
    }

    void SpawnRock()
    {
        float spawnXPosition = Random.Range(-6.7f, -2.80f);
        Vector3 spawnPosition = new Vector3(spawnXPosition, transform.position.y, transform.position.z);
        Instantiate(rockPrefab, spawnPosition, Quaternion.identity);
    }
}
