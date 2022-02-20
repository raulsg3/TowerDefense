using UnityEngine;

namespace TowerDefense
{
    [CreateAssetMenu(menuName = "TowerDefense/Economy/Economy Configuration Data", fileName = "EconomyConfigData")]
    public class EconomyConfigData : ScriptableObject
    {
        [SerializeField]
        private int _initialCoins = 0;

        public int InitialCoins => _initialCoins;
    }
}
