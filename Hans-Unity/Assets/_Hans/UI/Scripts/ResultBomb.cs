using UnityEngine;

public class ResultBomb : FruitBase
{
    public override void Launch(Vector3 direction, float force)
    {
        // �s�v
    }

    public override void Cut(Vector3 cutDirection)
    {
        Debug.Log("���e��؂��� �� �^�C�g����ʂɖ߂�");

        // ��\��
        GameManager.Instance.HideResultObjects();

        // �^�C�g����
        GameManager.Instance.EndGame();
        GameManager.Instance.resultUI.SetActive(false);
    }
}