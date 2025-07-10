using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public FruitFactory fruitFactory;
    public Transform    leftSpawnPoint;
    public Transform    rightSpawnPoint;
    public float        spawnInterval = 2f;
    public float        minForce = 4f;
    public float        maxForce = 7f;

    private float       timer = 0;

    private void Update()
    {
        if (!GameManager.Instance.IsGameStarted)
        {
            return;
        }

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnFruit();
            timer = 0f;
        }
    }

    private void SpawnFruit()
    {
        int fruitsPerSpawn = Random.Range(1, 3);

        for (int i = 0; i < fruitsPerSpawn; i++)
        {
            Transform spawnPoint = Random.value > 0.5f ? leftSpawnPoint : rightSpawnPoint;
            float r = Random.value;
            string fruitType;

            if (r < 0.45f)
            {
                fruitType = "Watermelon";
            }
            else if (r < 0.9f)
            {
                fruitType = "Orenge";
            }
            else
            {
                fruitType = "Bomb";
            }

            FruitBase fruit = fruitFactory.CreateFruit(fruitType, spawnPoint.position);

            if (fruit != null)
            {
                Vector3 center = new Vector3(0, 3f, 0);
                Vector3 direction = (center - spawnPoint.position).normalized;
                float force = Random.Range(minForce, maxForce);
                fruit.Launch(direction, force);
            }
        }
    }
}