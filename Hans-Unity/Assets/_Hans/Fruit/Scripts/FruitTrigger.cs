using UnityEngine;

public class FruitTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        FruitBase fruit = other.GetComponent<FruitBase>();
        
        if (fruit != null)
        {
            GameManager.Instance.DecreaseHP();
            Destroy(other.gameObject);
        }
    }
}
