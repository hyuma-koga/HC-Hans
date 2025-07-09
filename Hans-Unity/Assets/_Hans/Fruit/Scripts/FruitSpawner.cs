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
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnFruit();
            timer = 0f;
        }
    }

    private void SpawnFruit()
    {
        Transform spawnPoint = Random.value > 0.5f ? leftSpawnPoint : rightSpawnPoint;

        // ƒ‰ƒ“ƒ_ƒ€‚É‰Ê•¨‚ÌŽí—Þ‚ð‘I‚Ô
        string fruitType = Random.value > 0.5f ? "Watermelon" : "Orenge";

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
