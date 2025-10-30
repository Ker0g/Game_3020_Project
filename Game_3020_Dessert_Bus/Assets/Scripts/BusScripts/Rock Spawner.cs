using UnityEngine;

public class RockSpawner : MonoBehaviour
{

    [SerializeField] GameObject rockPrefab;
    [SerializeField] GameObject tumbleweedPrefab;
    [SerializeField] float spawnInterval = 2f;
    [SerializeField] float resetTime = 2f;

    

    float difficultyTimer = 30f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnInterval -= Time.deltaTime;
        difficultyTimer -= Time.deltaTime;

        if (spawnInterval <= 0f)
        {
            int chooseObstacle = Random.Range(0, 2);

            if (chooseObstacle == 0)
                SpawnRock();
            else
                SpawnTumbleweed();
            spawnInterval = resetTime;
        }

        if (difficultyTimer <= 0f && resetTime > 0.5f)
        {
            resetTime -= 0.1f;
            difficultyTimer = 30f;
        }
    }

    void SpawnRock()
    {
        float spawnXPosition = Random.Range(-6.7f, -2.80f);
        Vector3 spawnPosition = new Vector3(spawnXPosition, transform.position.y, transform.position.z);
        Instantiate(rockPrefab, spawnPosition, Quaternion.identity);
    }

    void SpawnTumbleweed()
    {
        float spawnXPosition = Random.Range(-6.7f, -2.80f);
        Vector3 spawnPosition = new Vector3(spawnXPosition, transform.position.y, transform.position.z);
        Instantiate(tumbleweedPrefab, spawnPosition, Quaternion.identity);
    }
}
