using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private BulletConfigData _bulletConfigData;

    public float Damage => _bulletConfigData.Damage;

    private Vector3 _direction = Vector3.zero;

    public void ShootAt(Vector3 targetPosition)
    {
        _direction = targetPosition - transform.position;
    }

    private void Update()
    {
        transform.position += _direction * Time.deltaTime * _bulletConfigData.Speed;
    }
}
