using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    [CreateAssetMenu(menuName = "TowerDefense/Creeps/Normal Creeps Configuration Data", fileName = "Normal Creeps Configuration Data")]
    public class NormalCreepsConfigData : ScriptableObject
    {
        [SerializeField]
        private float _speed = 0f;

        [SerializeField]
        private float _health = 1f;

        [SerializeField]
        private float _damage = 0f;

        public float Speed => _speed;
        public float Health => _health;
        public float Damage => _damage;
    }
}

