﻿using UnityEngine;

namespace TowerDefense
{
    public class PlayerBaseHealth : PlayerStructureHealth
    {
        public override void Die()
        {
            Debug.Log("PlayerBase destroyed");
        }
    }
}
