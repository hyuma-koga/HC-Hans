using UnityEngine;
using System.Collections.Generic;

public class PlayerCutter : MonoBehaviour
{
    public int            maxPoints = 20;
    public float          pointSpacing = 0.1f;
    private LineRenderer  lineRenderer;
    private List<Vector3> points = new List<Vector3>();
    private Vector3       lastMousePos;

    private void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 0;
        lineRenderer.material = new Material(Shader.Find("Legacy Shaders/Particles/Additive"));

        lineRenderer.widthCurve = new AnimationCurve(
            new Keyframe(0, 0.5f),
            new Keyframe(1, 0.05f)
        );

        Gradient gradient = new Gradient();

        gradient.SetKeys(
            new GradientColorKey[]
            {
            new GradientColorKey(Color.white, 0.0f),
            new GradientColorKey(Color.cyan, 0.5f),
            new GradientColorKey(Color.white, 1.0f)
            },
            new GradientAlphaKey[]
            {
            new GradientAlphaKey(0.0f, 0.0f),
            new GradientAlphaKey(1.0f, 0.1f),
            new GradientAlphaKey(0.0f, 1.0f)
            }
        );

        lineRenderer.colorGradient = gradient;
        lineRenderer.numCapVertices = 5;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 currentMousePos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(currentMousePos);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                FruitBase fruit = hit.collider.GetComponent<FruitBase>();

                if (fruit != null)
                {
                    fruit.Cut((currentMousePos - lastMousePos).normalized);
                }
            }

            Vector3 linePos = currentMousePos;
            linePos.z = 10f;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(linePos);

            if (points.Count == 0 || Vector3.Distance(worldPos, points[0]) > pointSpacing)
            {
                points.Insert(0, worldPos);

                if (points.Count > maxPoints)
                {
                    points.RemoveAt(points.Count - 1);
                }

                lineRenderer.positionCount = points.Count;
                lineRenderer.SetPositions(points.ToArray());
            }

            lastMousePos = currentMousePos;
        }
        else
        {
            points.Clear();
            lineRenderer.positionCount = 0;
        }
    }
}