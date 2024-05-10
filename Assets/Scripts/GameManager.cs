using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    bool isPaused;

    public GameObject player;
    public float score;

    [SerializeField] GameObject deathScreen;
    [SerializeField] GameObject pauseScreen;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(this);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void GameOver()
    {
        deathScreen.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void TogglePause()
    {
        pauseScreen.SetActive(isPaused ? false : true);
        Time.timeScale = isPaused ? 1f : 0f;
        isPaused = !isPaused;
    }
}
