using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(DeathEnemiesHandler))]

public class SpeedEffect : MonoBehaviour
{
    [SerializeField] private float _speedEffectModifier = 2;
    [SerializeField] private float _durationOfTheSpeedEffect = 2;

    private DeathEnemiesHandler _deathEnemiesHandler;

    public event UnityAction<float, float> SpeedEffectActivated;

    private void Awake()
    {
        _deathEnemiesHandler = GetComponent<DeathEnemiesHandler>();
    }

    private void OnEnable()
    {
        _deathEnemiesHandler.EnemyDead += OnEnemyDead;
    }

    private void OnDisable()
    {
        _deathEnemiesHandler.EnemyDead -= OnEnemyDead;
    }

    private void OnEnemyDead()
    {
        SpeedEffectActivated?.Invoke(_speedEffectModifier, _durationOfTheSpeedEffect);
    }
}
