using UnityEngine;

public class WatermelonRotator : MonoBehaviour
{
    public float rotateSpeedX = 50f;
    public float rotateSpeedY = 50f;
    public float rotateSpeedZ = 0f;

    private void Update()
    {
        transform.Rotate(
            new Vector3(rotateSpeedX, rotateSpeedY, rotateSpeedZ) * Time.deltaTime,
            Space.Self
        );
    }
}
