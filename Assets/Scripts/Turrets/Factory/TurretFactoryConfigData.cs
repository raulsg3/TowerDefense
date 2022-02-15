using System;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    [CreateAssetMenu(menuName = "TowerDefense/Turrets/Factory/Turret Factory Configuration Data", fileName = "TurretFactoryConfigData")]
    public class TurretFactoryConfigData : ScriptableObject
    {
        [SerializeField]
        private Turret[] _turrets;

        private Dictionary<Turret.EType, Turret> _turretsByType;

        void Awake()
        {
            _turretsByType = new Dictionary<Turret.EType, Turret>();

            foreach (Turret turret in _turrets)
            {
                _turretsByType.Add(turret.Type, turret);
            }
        }

        public Turret GetTurretByType(Turret.EType type)
        {
            if (!_turretsByType.TryGetValue(type, out var turret))
                throw new Exception($"Turret with id {type} not found");

            return turret;
        }
    }
}
