using UnityEngine;

public class UIRotator : MonoBehaviour
{
    public float rotateSpeed = 20f;

    private void Update()
    {
        transform.Rotate(0f, 0f, -rotateSpeed * Time.deltaTime);
    }
}
