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
        Debug.Log("�Q�[���X�^�[�g�������s");
        titleUI.SetActive(false);
        GameUI.SetActive(true);
    }
}
