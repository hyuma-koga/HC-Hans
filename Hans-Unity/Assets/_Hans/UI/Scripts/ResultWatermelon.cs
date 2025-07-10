using UnityEngine;

public class ResultWatermelon : FruitBase
{
    [SerializeField] private GameObject pb_leftHalf;
    [SerializeField] private GameObject pb_rightHalf;
    [SerializeField] private float splitForce = 1.5f;

    public override void Launch(Vector3 direction, float force)
    {
    }

    public override void Cut(Vector3 cutDirection)
    {
        Debug.Log("ÉXÉCÉJÇêÿÇ¡ÇΩ Å® Restart!");

        GameObject left = Instantiate(pb_leftHalf, transform.position, transform.rotation);
        GameObject right = Instantiate(pb_rightHalf, transform.position, transform.rotation);

        right.transform.Rotate(0, 180f, 0);

        Rigidbody leftRb = left.GetComponent<Rigidbody>();
        Rigidbody rightRb = right.GetComponent<Rigidbody>();

        leftRb.AddForce((-cutDirection + Vector3.left * 0.5f + Vector3.down * 0.5f) * splitForce, ForceMode.Impulse);
        rightRb.AddForce((cutDirection + Vector3.right * 0.5f + Vector3.down * 0.5f) * splitForce, ForceMode.Impulse);

        Destroy(gameObject);

        GameManager.Instance.HideResultObjects();
        GameManager.Instance.StartGame();
    }
}