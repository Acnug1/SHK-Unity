using UnityEngine;
using UnityEngine.Events;

public class DeathEnemiesHandler : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _enemiesContainer;
    [SerializeField] private float _killEnemyDistance = 0.2f;

    private Enemy[] _enemies;

    public event UnityAction EnemyDead;
    public event UnityAction<Player> AllEnemiesDead;

    private void Update()
    {
        CheckEnemiesCount();

        CheckDistanceToThePlayer();
    }

    private void CheckEnemiesCount()
    {
        _enemies = _enemiesContainer.GetComponentsInChildren<Enemy>();

        if (_enemies.Length == 0)
            AllEnemiesDead?.Invoke(_player);
    }

    private void CheckDistanceToThePlayer()
    {
        foreach (var enemy in _enemies)
        {
            if (enemy == null)
                continue;

            if (Vector3.Distance(_player.transform.position, enemy.transform.position) < _killEnemyDistance)
            {
                DestroyEnemy(enemy);
                EnemyDead?.Invoke();
            }
        }
    }

    private void DestroyEnemy(Enemy enemy)
    {
        Destroy(enemy.gameObject);
    }
}
