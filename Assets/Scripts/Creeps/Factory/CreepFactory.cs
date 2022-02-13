using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class CreepFactory : MonoBehaviour
    {
        [SerializeField]
        private CreepFactoryConfigData _creepFactoryConfigData;

        public Creep CreateCreep(Creep.EType type)
        {
            Creep creepPrefab = _creepFactoryConfigData.GetCreepByType(type);
            return Instantiate(creepPrefab);
        }
    }
}
