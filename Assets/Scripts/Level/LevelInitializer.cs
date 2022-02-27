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

        private IEventService _eventManagerService;

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
            ServiceLocatorSingleton.Instance.ClearServices();
            InitLevel();
        }

        private void Start()
        {
            ServiceLocatorSingleton.Instance.GetService<IEventService>().OnTurretPositionChosen += _placeTurretController.PlaceTurret;

            ServiceLocatorSingleton.Instance.GetService<IEventService>().OnCreepSpawned += _creepCounter.IncreaseCreepsRemaining;
            ServiceLocatorSingleton.Instance.GetService<IEventService>().OnCreepEliminated += _creepCounter.DecreaseCreepsRemaining;

            ServiceLocatorSingleton.Instance.GetService<IEventService>().OnCreepEliminated += _economyController.CollectCoins;

            StartLevel();
        }

        private void OnDestroy()
        {
            ServiceLocatorSingleton.Instance.GetService<IEventService>().OnTurretPositionChosen -= _placeTurretController.PlaceTurret;

            ServiceLocatorSingleton.Instance.GetService<IEventService>().OnCreepSpawned -= _creepCounter.IncreaseCreepsRemaining;
            ServiceLocatorSingleton.Instance.GetService<IEventService>().OnCreepEliminated -= _creepCounter.DecreaseCreepsRemaining;

            ServiceLocatorSingleton.Instance.GetService<IEventService>().OnCreepEliminated -= _economyController.CollectCoins;
        }

        private void InitLevel()
        {
            GameObject _playerBase = GameObject.FindWithTag(Tags.PlayerBase);

            if (_playerBase.TryGetComponent(out PlayerBaseHealth playerBaseHealth))
                playerBaseHealth.SetHealth(Instantiate(_playerBaseConfigData).Health);

            _eventManagerService = new EventService();
            ServiceLocatorSingleton.Instance.RegisterService<IEventService>(_eventManagerService);

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
