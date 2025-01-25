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

    string currentLevel;
    LevelManager currentLevelManager;

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
        
    }

    /// <summary>
    /// Unloads the current menu and loads the home screen menu
    /// </summary>
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MAIN");
    }

    /// <summary>
    /// Loads the specified level
    /// </summary>
    /// <param name="scene"></param>
    public void LoadLevel(Scene scene)
    {
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
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
