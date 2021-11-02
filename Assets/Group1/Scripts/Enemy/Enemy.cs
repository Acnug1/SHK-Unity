using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _targetRadius = 4;
    [SerializeField] private float _speed = 2;

    private Vector3 _target;

    private void Start()
    {
        SetTarget();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

        if (transform.position == _target)
            SetTarget();
    }

    private void SetTarget()
    {
        _target = Random.insideUnitCircle * _targetRadius;
    }
}
