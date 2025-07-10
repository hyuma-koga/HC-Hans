using UnityEngine;

public class ResultBomb : FruitBase
{
    public override void Launch(Vector3 direction, float force)
    {
    }

    public override void Cut(Vector3 cutDirection)
    {
        GameManager.Instance.HideResultObjects();
        GameManager.Instance.EndGame();
        GameManager.Instance.resultUI.SetActive(false);
    }
}