using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    [CreateAssetMenu(menuName = "TowerDefense/Creeps/Factory/Creep Factory Configuration Data", fileName = "CreepFactoryConfigData")]
    public class CreepFactoryConfigData : ScriptableObject
    {
        [SerializeField]
        private Creep[] _creeps;

        private Dictionary<Creep.EType, Creep> _creepsByType;

        void Awake()
        {
            _creepsByType = new Dictionary<Creep.EType, Creep>();

            foreach (Creep creep in _creeps)
            {
                _creepsByType.Add(creep.Type, creep);
            }
        }

        public Creep GetCreepByType(Creep.EType type)
        {
            if (!_creepsByType.TryGetValue(type, out var creep))
                throw new Exception($"Creep with id {type} not found");

            return creep;
        }
    }
}
