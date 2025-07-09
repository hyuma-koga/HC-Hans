using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject         titleUI;
    public GameObject         gameUI;
    public GameObject         gameOverUI;
    public GameObject         resultUI;
    public TMP_Text           scoreText;
    public TMP_Text           bestScoreText;
    public List<Image>        hpImages;
    public bool               IsGameStarted {  get; private set; } = false;
    private int               currentScore = 0;
    private int               bestScore = 0;
    private int               hp = 3;

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

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        UpdateScoreUI();
    }

    public void StartGame()
    {
        Debug.Log("ゲームスタート処理実行");
        titleUI.SetActive(false);
        gameUI.SetActive(true);
        gameOverUI.SetActive(false);
        resultUI.SetActive(false);
        ResetScore();
        ResetHP();
        IsGameStarted = true;
    }

    public void EndGame()
    {
        titleUI.SetActive(true);
        gameUI.SetActive(false);
        IsGameStarted = false;
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        currentScore += amount;

        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save();
        }

        UpdateScoreUI();
    }

    public void DecreaseHP()
    {
        hp--;
        UpdateHPImages();

        if (hp <= 0)
        {
            StartCoroutine(GameOverSequence());
        }
    }

    private IEnumerator GameOverSequence()
    {
        gameOverUI.SetActive(true);
        yield return new WaitForSeconds(3f);
        gameOverUI.SetActive(false);
        resultUI.SetActive(true);
    }

    private void ResetScore()
    {
        currentScore = 0;
        UpdateScoreUI();
    }

    private void ResetHP()
    {
        hp = 3;
        UpdateHPImages();
    }

    private void UpdateScoreUI()
    {
        scoreText.text = $"{currentScore}";
        bestScoreText.text = $"{bestScore}";
    }

    private void UpdateHPImages()
    {
        for (int i = 0; i < hpImages.Count; i++)
        {
            if (i < 3 - hp)
            {
                hpImages[i].color = Color.red;
            }
            else
            {
                hpImages[i].color = Color.white;
            }
        }
    }
}
