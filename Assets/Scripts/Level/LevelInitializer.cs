﻿using System.Collections;
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

        [Header("Turrets")]
        [SerializeField]
        private TurretFactoryConfigData _turretFactoryConfigData;

        [Header("")]
        [SerializeField]
        private LevelController _levelController;

        private ISpawnPointsController _spawnPointsController;

        private ICreepFactory _creepFactory;
        private ICreepWaveSpawner _creepWaveSpawner;
        private IWavesController _wavesController;

        private ITurretFactory _turretFactory;
        private ITurretSpawner _turretSpawner;
        private ITurretController _turretController;

        void Awake()
        {
            InitLevel();
            StartLevel();
        }

        private void InitLevel()
        {
            GameObject _playerBase = GameObject.FindWithTag(Tags.PlayerBase);

            if (_playerBase.TryGetComponent(out PlayerBaseHealth playerBaseHealth))
            {
                playerBaseHealth.SetHealth(Instantiate(_playerBaseConfigData).Health);
            }

            _turretFactory = new TurretFactory(Instantiate(_turretFactoryConfigData));
            _turretSpawner = new TurretSpawner(_turretFactory);
            _turretController = new TurretController(_turretSpawner);

            _spawnPointsController = new SpawnPointsController(Instantiate(_spawnPointsConfigData));

            _creepFactory = new CreepFactory(Instantiate(_creepFactoryConfigData));
            _creepWaveSpawner = new CreepWaveSpawner(_creepFactory, _spawnPointsController, _playerBase.transform.position, this);

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
