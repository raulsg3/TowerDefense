using System.Collections;
using UnityEngine;

namespace TowerDefense
{
    public class LevelInitializer : MonoBehaviour
    {
        [Header("Waves")]
        [SerializeField]
        private MultipleWavesConfigData _multipleWavesConfigData;

        private MultipleWavesConfigData _multipleWavesConfigDataInstance;

        [Header("Creeps")]
        [SerializeField]
        private CreepFactoryConfigData _creepFactoryConfigData;

        [SerializeField]
        private SpawnPointsConfigData _spawnPointsConfigData;

        [Header("")]
        [SerializeField]
        private PlayerBaseConfigData _playerBaseConfigData;

        [SerializeField]
        private TurretFactoryConfigData _turretFactoryConfigData;

        [SerializeField]
        private EconomyConfigData _economyConfigData;

        [SerializeField]
        private LevelController _levelController;

        [SerializeField]
        private UIController _uiController;

        private ISpawnPointsController _spawnPointsController;

        private ICreepCounter _creepCounter;
        private ICreepFactory _creepFactory;
        private ICreepWaveSpawner _creepWaveSpawner;
        private IWavesController _wavesController;

        private ITurretFactory _turretFactory;
        private ITurretSpawner _turretSpawner;
        private IPlaceTurretController _placeTurretController;

        private Money _money;
        private IEconomyController _economyController;

        private void Awake()
        {
            InitLevel();
        }

        private void Start()
        {
            EventManagerSingleton.Instance.OnTurretPositionChosen += _placeTurretController.PlaceTurret;

            EventManagerSingleton.Instance.OnCreepSpawned += _creepCounter.IncreaseCreepsRemaining;
            EventManagerSingleton.Instance.OnCreepEliminated += _creepCounter.DecreaseCreepsRemaining;

            EventManagerSingleton.Instance.OnCreepEliminated += _economyController.CollectCoins;

            StartLevel();
        }

        private void OnDestroy()
        {
            EventManagerSingleton.Instance.OnTurretPositionChosen -= _placeTurretController.PlaceTurret;

            EventManagerSingleton.Instance.OnCreepSpawned -= _creepCounter.IncreaseCreepsRemaining;
            EventManagerSingleton.Instance.OnCreepEliminated -= _creepCounter.DecreaseCreepsRemaining;

            EventManagerSingleton.Instance.OnCreepEliminated -= _economyController.CollectCoins;
        }

        private void InitLevel()
        {
            GameObject _playerBase = GameObject.FindWithTag(Tags.PlayerBase);

            if (_playerBase.TryGetComponent(out PlayerBaseHealth playerBaseHealth))
                playerBaseHealth.SetHealth(Instantiate(_playerBaseConfigData).Health);

            _money = new Money(Instantiate(_economyConfigData).InitialCoins);
            _economyController = new EconomyController(_money, _uiController);

            _turretFactory = new TurretFactory(Instantiate(_turretFactoryConfigData));
            _turretSpawner = new TurretSpawner(_turretFactory);
            _placeTurretController = new PlaceTurretController(_turretSpawner, _turretFactory, _economyController);

            _spawnPointsController = new SpawnPointsController(Instantiate(_spawnPointsConfigData));

            _creepCounter = new CreepCounter();
            _creepFactory = new CreepFactory(Instantiate(_creepFactoryConfigData));
            _creepWaveSpawner = new CreepWaveSpawner(_creepFactory, _spawnPointsController, _playerBase.transform.position, this);

            _multipleWavesConfigDataInstance = Instantiate(_multipleWavesConfigData);
            _wavesController = new WavesController(_multipleWavesConfigDataInstance, _creepWaveSpawner);

            _levelController.Init(_uiController, _multipleWavesConfigDataInstance, _wavesController);
        }

        private void StartLevel()
        {
            _levelController.StartLevel();
        }
    }
}
