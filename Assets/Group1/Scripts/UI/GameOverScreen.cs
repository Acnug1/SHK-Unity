using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _gameOverScreen;
    [SerializeField] private DeathEnemiesHandler _deathEnemiesHandler;

    private void Awake()
    {
        DisableGameOverScreen();
    }

    private void DisableGameOverScreen()
    {
        _gameOverScreen.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _deathEnemiesHandler.AllEnemiesDead += OnAllEnemiesDead;
    }

    private void OnDisable()
    {
        _deathEnemiesHandler.AllEnemiesDead -= OnAllEnemiesDead;
    }

    private void OnAllEnemiesDead(Player player)
    {
        DisablePlayer(player);
        
        EnableGameOverScreen();

        Time.timeScale = 0;
    }

    private void DisablePlayer(Player player)
    {
        player.gameObject.SetActive(false);
    }

    private void EnableGameOverScreen()
    {
        _gameOverScreen.gameObject.SetActive(true);
    }
}
