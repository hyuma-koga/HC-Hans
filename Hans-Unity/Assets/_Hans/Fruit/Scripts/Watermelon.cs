using UnityEngine;

public class Watermelon : FruitBase
{
    [SerializeField] private GameObject leftHalfPrefab;
    [SerializeField] private GameObject rightHalfPrefab;

    public override void Launch(Vector3 direction, float force)
    {
        rb.AddForce(direction * force, ForceMode.Impulse);
    }

    public override void Cut(Vector3 cutDirection)
    {
        GameObject left = Instantiate(leftHalfPrefab, transform.position, transform.rotation);
        GameObject right = Instantiate(rightHalfPrefab, transform.position, transform.rotation);

        Rigidbody leftRb = left.GetComponent<Rigidbody>();
        Rigidbody rightRb = right.GetComponent<Rigidbody>();

        leftRb.AddForce((-cutDirection + Vector3.left) * 3f, ForceMode.Impulse);
        rightRb.AddForce((cutDirection + Vector3.right) * 3f, ForceMode.Impulse);

        Destroy(gameObject);
    }
}
