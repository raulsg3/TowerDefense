using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class CreepMovement : MonoBehaviour
    {
        GameObject _target;
        private float _speed = 5f;

        void Start()
        {
            _target = GameObject.FindWithTag(Tags.PlayerBase);
        }

        void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
        }
    }
}
