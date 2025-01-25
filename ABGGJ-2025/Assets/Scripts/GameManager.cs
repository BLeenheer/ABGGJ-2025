using JetBrains.Annotations;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Prefabs")]
    [SerializeField]
    public GameObject playerController;

    [Header("UI Elements")]
    [SerializeField]
    GameObject mainMenuUI;
    [SerializeField]
    GameObject pauseUI;
    [SerializeField]
    GameObject levelUI;

    bool paused = false;
    string currentLevel;
    LevelManager currentLevelManager;

    int deathCount = 0, bubblePopCount = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (playerController == null) Debug.LogError("Player is not set in GameManager!");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    /// <summary>
    /// Unloads the current menu and loads the home screen menu
    /// </summary>
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MAIN");
        ResetGame();
        mainMenuUI.SetActive(true);
        levelUI.SetActive(false);
    }

    /// <summary>
    /// Loads the specified level
    /// </summary>
    /// <param name="scene"></param>
    public void LoadLevel(Scene scene)
    {
        mainMenuUI.SetActive(false);
        levelUI.SetActive(true);
        LoadLevel(scene.name);
    }

    /// <summary>
    /// Loads the specfied level
    /// </summary>
    /// <param name="sceneName"></param>
    public void LoadLevel(string sceneName)
    {
        if (currentLevel != null) SceneManager.UnloadSceneAsync(currentLevel);        
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        currentLevel = sceneName;
    }

    public void SetLevelManager(LevelManager levelManager)
    {
        this.currentLevelManager = levelManager;
    }

    public void WinGame()
    {
        //TODO: Win the game!
        //Loads the GAME_WIN screen
        SceneManager.LoadScene("GAME_WIN");
    }

    /// <summary>
    /// Forces the game to quit out NOW. Not applicable to web builds.
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
    }

    void ResetGame()
    {
        deathCount = 0;
        bubblePopCount = 0;
        Resume();
    }

    /// <summary>
    /// Stops time and shows the pause menu
    /// </summary>
    public void Pause()
    {
        paused = true;
        Time.timeScale = 0f;
        pauseUI.SetActive(true);
    }

    /// <summary>
    /// Resumes time and closes the pause menu
    /// </summary>
    public void Resume()
    {
        paused = false;
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
    }

    /// <summary>
    /// Adds +1 death to the death counter
    /// </summary>
    public void IncrementDeathCount()
    {
        deathCount++;
    }

    /// <summary>
    /// Adds +1 bubble pop to the bubble pop counter
    /// </summary>
    public void IncrementBubblePopCount()
    {
        bubblePopCount++;
    }
}
