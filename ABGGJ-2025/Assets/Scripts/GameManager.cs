using JetBrains.Annotations;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Prefabs")]
    [SerializeField]
    GameObject playerController;

    Scene currentLevel;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MAIN");
    }


    public void LoadLevel(Scene scene)
    {
        LoadLevel(scene.name);
    }

    public void LoadLevel(string sceneName)
    {
        if (currentLevel != null) SceneManager.UnloadSceneAsync(currentLevel);        
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        currentLevel = SceneManager.GetSceneByName(sceneName);
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
