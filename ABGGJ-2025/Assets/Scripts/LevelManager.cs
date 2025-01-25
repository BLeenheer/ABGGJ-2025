using UnityEngine;
using UnityEngine.SceneManagement;

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
    }

    public void RespawnPlayer()
    {

    }

    /// <summary>
    /// Load the next level according to this level's properties.
    /// </summary>
    public void NextLevel()
    {
        GameManager.Instance.LoadLevel(nextLevel);
    }
}
