using UnityEngine;

public class Bomb : FruitBase
{
    //[SerializeField] private float splitForce = 1.5f;

    public override void Launch(Vector3 direction, float force)
    {
        rb.AddForce(direction * force, ForceMode.Impulse);
    }

    public override void Cut(Vector3 cutDirection)
    {
        Destroy(gameObject);

        // Bomb��؂�����HP����C��0�ɂ���
        while (GameManager.Instance.HP > 0)
        {
            GameManager.Instance.DecreaseHP();
        }
    }
}