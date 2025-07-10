using UnityEngine;

public class FruitTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        FruitBase fruit = other.GetComponent<FruitBase>();

        if (fruit != null)
        {
            if (fruit is Bomb)
            {
                Destroy(other.gameObject);
                return;
            }

            GameManager.Instance.DecreaseHP();
            Destroy(other.gameObject);
        }
    }
}