using System.Collections;
using UnityEngine;

namespace TowerDefense
{
    public class LevelInitializer : MonoBehaviour
    {
        [SerializeField]
        private MultipleWavesConfigData _multipleWavesConfigData;

        private MultipleWavesConfigData _multipleWavesConfigDataInstance;

        [SerializeField]
        private CreepFactoryConfigData _creepFactoryConfigData;

        [SerializeField]
        private LevelController _levelController;

        private ICreepFactory _creepFactory;
        private ICreepWaveSpawner _creepWaveSpawner;
        private IWavesController _wavesController;

        void Awake()
        {
            InitLevel();
            StartLevel();
        }

        private void InitLevel()
        {
            GameObject _playerBase = GameObject.FindWithTag(Tags.PlayerBase);

            _creepFactory = new CreepFactory(Instantiate(_creepFactoryConfigData));
            _creepWaveSpawner = new CreepWaveSpawner(_creepFactory, this, _playerBase.transform.position);

            _multipleWavesConfigDataInstance = Instantiate(_multipleWavesConfigData);
            _wavesController = new WavesController(_multipleWavesConfigDataInstance, _creepWaveSpawner);

            _levelController.Init(_multipleWavesConfigDataInstance, _wavesController);
        }

        private void StartLevel()
        {
            _levelController.StartLevel();
        }
    }
}
