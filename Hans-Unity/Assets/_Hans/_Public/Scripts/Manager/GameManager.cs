using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject         titleUI;
    public GameObject         readyUI;
    public GameObject         goUI;
    public GameObject         gameUI;
    public GameObject         gameOverUI;
    public GameObject         resultUI;
    public GameObject         missImage;
    public GameObject         resultWatermelon;
    public GameObject         resultBomb;
    public GameObject         titleWatermelonPrefab;
    public GameObject         resultWatermelonPrefab;
    public Transform          titleWatermelonParent;
    public Transform          resultWatermelonParent;
    public TMP_Text           scoreText;
    public TMP_Text           bestScoreText;
    public TMP_Text           resultScoreText;
    public List<Image>        hpImages;
    public bool               IsGameStarted { get; private set; } = false;
    public int                HP => hp;

    private GameObject        currentTitleWatermelon;
    private GameObject        currentResultWatermelon;
    private int               hp = 3;
    private int               currentScore = 0;
    private int               bestScore = 0;
   
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
        titleUI.SetActive(false);

        if (currentTitleWatermelon != null)
        {
            Destroy(currentTitleWatermelon);
        }

        gameUI.SetActive(true);
        readyUI.SetActive(true);
        goUI.SetActive(false);
        gameOverUI.SetActive(false);
        resultUI.SetActive(false);
        missImage.SetActive(false);

        ResetScore();
        ResetHP();

        Time.timeScale = 0.7f;
        StartCoroutine(StartGameSequence());
    }

    private IEnumerator StartGameSequence()
    {
        yield return new WaitForSeconds(1f);
        readyUI.SetActive(false);

        goUI.SetActive(true);
        yield return new WaitForSeconds(1f);
        goUI.SetActive(false);

        IsGameStarted = true;
    }

    public void EndGame()
    {
        titleUI.SetActive(true);
        gameUI.SetActive(false);
        readyUI.SetActive(false);
        goUI.SetActive(false);
        resultUI.SetActive(false);
        IsGameStarted = false;
        UpdateScoreUI();

        if (titleWatermelonParent != null)
        {
            currentTitleWatermelon = Instantiate(titleWatermelonPrefab, titleWatermelonParent);
        }
    }

    public void AddScore(int amount)
    {
        if (!IsGameStarted)
        {
            return;
        }

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

        ShowMissImage();

        if (hp <= 0)
        {
            StartCoroutine(GameOverSequence());
        }
    }

    public IEnumerator GameOverSequence()
    {
        gameOverUI.SetActive(true);
        IsGameStarted = false;
        yield return new WaitForSeconds(3f);
        gameOverUI.SetActive(false);
        
        if (resultScoreText != null)
        {
            resultScoreText.text = $"{currentScore}";
        }

        if (resultWatermelon != null)
        {
            currentResultWatermelon = Instantiate(resultWatermelonPrefab, resultWatermelonParent);
        }

        if (resultBomb != null)
        {
            resultBomb.SetActive(true);
        }

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

    public void ShowMissImage()
    {
        StartCoroutine(ShowMissImageCoroutine());
    }

    private IEnumerator ShowMissImageCoroutine()
    {
        missImage.SetActive(true);
        yield return new WaitForSeconds(1f);
        missImage.SetActive(false);
    }

    public void HideResultObjects()
    {
        if (currentResultWatermelon != null)
        {
            Destroy(currentResultWatermelon);
        }

        if (resultBomb != null)
        {
            resultBomb.SetActive(false);
        }
    }
}