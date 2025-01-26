using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages the current level. Will contain different data when a new level is loaded.
/// </summary>
public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [SerializeField]
    public string nextLevel;
    [SerializeField]
    Transform playerSpawnPoint;

    bool isRespawning;

    private void Awake()
    {
        //I don't want to lose the new level manager if the scene is transitioning.
        //This will override the "Instance" and the old instance will be unloaded.
        Instance = this;
        GameManager.Instance.SetLevelManager(this);
    }

    private void Start()
    {
        RespawnPlayer();
    }

    /// <summary>
    /// Respawns the player back at the spawn point.
    /// </summary>
    public void RespawnPlayer()
    {
        if (!isRespawning)
        {
            isRespawning = true;
            Debug.Log("LevelManager: Respawning Player");
            Instantiate(GameManager.Instance.playerController, playerSpawnPoint.transform.position, new Quaternion(0, 0, 0, 0));
            isRespawning = false;
        }
    }

    /// <summary>
    /// Load the next level according to this level's properties.
    /// </summary>
    public void NextLevel()
    {
        GameManager.Instance.LoadLevel(nextLevel);
    }
}
