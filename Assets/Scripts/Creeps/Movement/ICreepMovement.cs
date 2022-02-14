using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public abstract class ICreepMovement : MonoBehaviour
    {
        protected Vector3 _targetPosition;
        protected float _speed = 0f;

        public void SetSpeed(float speed)
        {
            _speed = speed;
        }

        public void SetTarget(Vector3 targetPosition)
        {
            _targetPosition = targetPosition;
        }
    }
}
