using UnityEngine;

[CreateAssetMenu(menuName = "TowerDefense/Turrets/Bullet Configuration Data", fileName = "BulletConfigData")]
public class BulletConfigData : ScriptableObject
{
    [SerializeField]
    private float _speed = 5f;

    [SerializeField]
    private float _damage = 1f;

    public float Speed => _speed;

    public float Damage => _damage;
}

