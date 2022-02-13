using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class CreepFactory : MonoBehaviour
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

        public Creep CreateCreep(Creep.EType type)
        {
            Creep creep;

            if (!_creepTypes.TryGetValue(type, out creep))
                throw new Exception($"Creep with id {type} not found");

            return Instantiate(creep);
        }
    }
}
