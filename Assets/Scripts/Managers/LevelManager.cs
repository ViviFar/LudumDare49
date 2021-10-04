using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : GenericSingleton<LevelManager>
{
    [SerializeField]
    private GameObject pauseMenuPanel;

    [SerializeField]
    private GameObject victoryScreenPanel;

    [SerializeField]
    private GameObject defeatScreenPanel;

    [SerializeField]
    private RawImage[] hearts;
    [SerializeField]
    private Texture fullHeart;
    [SerializeField]
    private Texture semiHeart;

    [SerializeField]
    private Transform bulletContainer;
    public Transform BulletContainer
    {
        get { return bulletContainer; }
    }

    private BossShoot boss;
    public BossShoot Boss
    {
        get { return boss; }
        set { boss = value; }
    }

    private bool isPaused = false;
    public bool IsPaused
    {
        get { return isPaused; }
    }

    private void Start()
    {
        pauseMenuPanel.SetActive(false);
        victoryScreenPanel.SetActive(false);
        defeatScreenPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                DeactivatePanels();
                Time.timeScale = 1;
                isPaused = false;
            }
            else
            {
                ShowPausePanel();
                Time.timeScale = 0;
                isPaused = true;
            }
        }
    }

    public void DeactivatePanels()
    {
        pauseMenuPanel.SetActive(false);
        victoryScreenPanel.SetActive(false);
        defeatScreenPanel.SetActive(false);
    }

    public void ShowPausePanel()
    {
        pauseMenuPanel.SetActive(true);
        victoryScreenPanel.SetActive(false);
        defeatScreenPanel.SetActive(false);
    }

    public void ShowVictoryPanel()
    {
        pauseMenuPanel.SetActive(false);
        victoryScreenPanel.SetActive(true);
        defeatScreenPanel.SetActive(false);
    }

    public void ShowDefeatPanel()
    {
        pauseMenuPanel.SetActive(false);
        victoryScreenPanel.SetActive(false);
        defeatScreenPanel.SetActive(true);
    }

    public void Resume()
    {
        DeactivatePanels();
        Time.timeScale = 1;
        isPaused = false;
    }

    public void RestartGame()
    {
        DeactivatePanels();
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void BackToMenu()
    {
        DeactivatePanels();
        Time.timeScale = 1;
        GameManager.Instance.CurrentState = Etats.Menu;
    }

    public void QuitGame()
    {
        Time.timeScale = 1;
        Application.Quit();
    }

    public void UpdateHealthUI(int currentLife)
    {
        int n = currentLife / 2;
        for (int i=0; i<5; i++)
        {
            if (n > i)
            {
                hearts[i].texture = fullHeart;
                hearts[i].enabled = true;
            }
            else if(n==i && currentLife % 2 == 1)
            {
                hearts[i].texture = semiHeart;
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
