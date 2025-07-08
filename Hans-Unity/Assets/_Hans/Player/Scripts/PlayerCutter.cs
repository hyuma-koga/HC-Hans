using UnityEngine;

public class PlayerCutter : MonoBehaviour
{
    private Vector3 lastMousePos;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 currentMousePos = Input.mousePosition;
            Vector3 direction = currentMousePos - lastMousePos;

            Ray ray = Camera.main.ScreenPointToRay(currentMousePos);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                FruitBase fruit = hit.collider.GetComponent<FruitBase>();
                if (fruit != null)
                {
                    fruit.Cut(direction.normalized);
                }
            }

            lastMousePos = currentMousePos;
        }
    }
}
