using UnityEngine;

public class Bomb : FruitBase
{
    public override void Launch(Vector3 direction, float force)
    {
        rb.AddForce(direction * force, ForceMode.Impulse);
    }

    public override void Cut(Vector3 cutDirection)
    {
        Destroy(gameObject);

        while (GameManager.Instance.HP > 0)
        {
            GameManager.Instance.DecreaseHP();
        }
    }
}