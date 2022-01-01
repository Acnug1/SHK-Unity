using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Player))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private SpeedEffect _speedEffect;

    private float _speedEffectModifier;

    private void OnEnable()
    {
        _speedEffect.SpeedEffectActivated += OnSpeedEffectActivated;
    }

    private void OnDisable()
    {
        _speedEffect.SpeedEffectActivated -= OnSpeedEffectActivated;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
            transform.Translate(0, _speed * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.S))
            transform.Translate(0, -_speed * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.A))
            transform.Translate(-_speed * Time.deltaTime, 0, 0);

        if (Input.GetKey(KeyCode.D))
            transform.Translate(_speed * Time.deltaTime, 0, 0);
    }

    private void OnSpeedEffectActivated(float speedEffectModifier, float durationOfTheSpeedEffect)
    {
        _speedEffectModifier = speedEffectModifier;
        _speed *= _speedEffectModifier;
        float time = durationOfTheSpeedEffect;

        StartCoroutine(SpeedSlowdown(time));
    }

    private IEnumerator SpeedSlowdown(float time)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(time);
        yield return waitForSeconds;

        SetDefaultSpeed();
    }

    private void SetDefaultSpeed()
    {
        _speed /= _speedEffectModifier;
    }
}
