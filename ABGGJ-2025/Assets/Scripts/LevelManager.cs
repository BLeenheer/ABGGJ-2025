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

    private void Awake()
    {
        //I don't want to lose the new level manager if the scene is transitioning.
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
        Instantiate(GameManager.Instance.playerController, playerSpawnPoint.transform.position, new Quaternion(0,0,0,0));
    }

    /// <summary>
    /// Load the next level according to this level's properties.
    /// </summary>
    public void NextLevel()
    {
        GameManager.Instance.LoadLevel(nextLevel);
    }
}
