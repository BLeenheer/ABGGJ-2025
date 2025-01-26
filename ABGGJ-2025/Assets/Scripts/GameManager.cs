using System.Runtime.CompilerServices;
using TMPro;
using Unity.Cinemachine;
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
    [SerializeField]
    TextMeshProUGUI TMP_DeathCount, TMP_BubblePopCount;

    [Header("Camera")]
    [SerializeField]
    CinemachineCamera cinemachineCamera;

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
        if(Input.GetKeyDown(KeyCode.Escape) && !mainMenuUI.activeSelf)
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
        levelUI.SetActive(true);
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
        TMP_DeathCount.text = "Deaths: " + deathCount.ToString();
        TMP_BubblePopCount.text = "Popped: " + bubblePopCount.ToString();
        levelUI.SetActive(false);
        Resume();
    }

    /// <summary>
    /// Respawns the player. Helps if stuck.
    /// </summary>
    public void RespawnPlayer()
    {
        if(paused) Resume();
        Destroy(PlayerController.Instance.gameObject);
        currentLevelManager.RespawnPlayer();
        Debug.Log("Respawning Player");
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
        TMP_DeathCount.text = "Deaths: " + deathCount.ToString();
        //Debug.Log("Bubbles Popped: " + deathCount);
    }

    /// <summary>
    /// Adds +1 bubble pop to the bubble pop counter
    /// </summary>
    public void IncrementBubblePopCount()
    {
        bubblePopCount++;
        TMP_BubblePopCount.text = "Popped: " + bubblePopCount.ToString();
        //Debug.Log("Bubbles Popped: " + bubblePopCount);
    }

    public void SetCameraTarget(Transform target)
    {
        cinemachineCamera.Target.TrackingTarget = target;
    }
}
