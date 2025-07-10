using UnityEngine;

public class ResultBomb : FruitBase
{
    public override void Launch(Vector3 direction, float force)
    {
        // 不要
    }

    public override void Cut(Vector3 cutDirection)
    {
        Debug.Log("爆弾を切った → タイトル画面に戻る");

        // 非表示
        GameManager.Instance.HideResultObjects();

        // タイトルへ
        GameManager.Instance.EndGame();
        GameManager.Instance.resultUI.SetActive(false);
    }
}