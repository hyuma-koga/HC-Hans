using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject         titleUI;
    public GameObject         GameUI;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {
        Debug.Log("ゲームスタート処理実行");
        titleUI.SetActive(false);
        GameUI.SetActive(true);
    }
}
