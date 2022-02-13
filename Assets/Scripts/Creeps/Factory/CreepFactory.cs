using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class CreepFactory : ICreepFactory
    {
        private readonly CreepFactoryConfigData _creepFactoryConfigData;

        public CreepFactory(CreepFactoryConfigData creepFactoryConfigData)
        {
            _creepFactoryConfigData = creepFactoryConfigData;
        }

        public Creep Create(Creep.EType type)
        {
            Creep creepPrefab = _creepFactoryConfigData.GetCreepByType(type);
            return GameObject.Instantiate(creepPrefab);
        }
    }
}
