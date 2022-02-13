using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    [CreateAssetMenu(menuName = "TowerDefense/Creeps/Factory/Creep Factory Configuration Data", fileName = "Creep Factory Configuration Data")]
    public class CreepFactoryConfigData : ScriptableObject
    {
        [SerializeField]
        private Creep[] _creeps;

        private Dictionary<Creep.EType, Creep> _creepTypes;

        public void Awake()
        {
            _creepTypes = new Dictionary<Creep.EType, Creep>();

            foreach (Creep creep in _creeps)
            {
                _creepTypes.Add(creep.Type, creep);
            }
        }

        public Creep GetCreepByType(Creep.EType type)
        {
            Creep creep;

            if (!_creepTypes.TryGetValue(type, out creep))
                throw new Exception($"Creep with id {type} not found");

            return creep;
        }
    }
}
