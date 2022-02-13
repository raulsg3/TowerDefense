using System.Collections;
using UnityEngine;

namespace TowerDefense
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField]
        private MultipleWavesConfigData _multipleWavesConfigData;

        private MultipleWavesConfigData _multipleWavesConfigDataInstance;

        [SerializeField]
        private CreepFactoryConfigData _creepFactoryConfigData;

        private ICreepFactory _creepFactory;
        private ICreepWaveSpawner _creepWaveSpawner;
        private IWavesController _wavesController;

        void Awake()
        {
            _creepFactory = new CreepFactory(Instantiate(_creepFactoryConfigData));
            _creepWaveSpawner = new CreepWaveSpawner(_creepFactory, this);

            _multipleWavesConfigDataInstance = Instantiate(_multipleWavesConfigData);
            _wavesController = new WavesController(_multipleWavesConfigDataInstance, _creepWaveSpawner);
        }

        void Start()
        {
            StartCoroutine(StartLevel());
        }

        private IEnumerator StartLevel()
        {
            WaitForSeconds initialWait = new WaitForSeconds(_multipleWavesConfigDataInstance.InitialWaitingTime);
            WaitForSeconds waitBetweenWaves = new WaitForSeconds(_multipleWavesConfigDataInstance.TimeBetweenWaves);

            yield return initialWait;

            while (_wavesController.AreWavesRemaining())
            {
                _wavesController.StartNextWave();
                yield return waitBetweenWaves;
            }
        }
    }
}
