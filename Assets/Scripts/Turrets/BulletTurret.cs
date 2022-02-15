using UnityEngine;

namespace TowerDefense
{
    public class BulletTurret : Turret
    {
        [SerializeField]
        private BulletTurretConfigData _bulletTurretConfigData;

        public float Damage => _bulletTurretConfigData.BulletDamage;

        public override void Init()
        {
            _turretHealth.SetHealth(_bulletTurretConfigData.Health);
        }
    }
}
