using UnityEngine;

public abstract class FruitBase : MonoBehaviour
{
    protected Rigidbody rb;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public abstract void Launch(Vector3 direction, float force);
    public abstract void Cut(Vector3 cutDirection);
}