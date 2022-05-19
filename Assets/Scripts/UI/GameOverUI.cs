using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject gameOverPanel;
    public float delayBeforeGameOverShow;
    public EnemyWaveManager waveManager;
    public TextMeshProUGUI waveReachedText;

    private void OnEnable()
    {
        playerHealth.OnDeath += OnPlayerDeath;
    }

    private void OnDisable()
    {
        playerHealth.OnDeath -= OnPlayerDeath;
    }

    private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    void OnPlayerDeath()
    {
        Invoke("ShowGameOverPanel", delayBeforeGameOverShow);
    }

    void ShowGameOverPanel()
    {
        waveReachedText.text = "You reached wave " + waveManager.GetWave();
        gameOverPanel.SetActive(true);
    }
}
