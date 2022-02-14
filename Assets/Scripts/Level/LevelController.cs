using System.Collections;
using UnityEngine;

namespace TowerDefense
{
    public class LevelController : MonoBehaviour
    {
        private MultipleWavesConfigData _multipleWavesConfigData;

        private IWavesController _wavesController;

        public void Init(MultipleWavesConfigData multipleWavesConfigDataInstance, IWavesController wavesController)
        {
            _multipleWavesConfigData = multipleWavesConfigDataInstance;
            _wavesController = wavesController;
        }

        public void StartLevel()
        {
            StartCoroutine(PlayLevel());
        }

        private IEnumerator PlayLevel()
        {
            WaitForSeconds initialWait = new WaitForSeconds(_multipleWavesConfigData.InitialWaitingTime);
            WaitForSeconds waitBetweenWaves = new WaitForSeconds(_multipleWavesConfigData.TimeBetweenWaves);

            yield return initialWait;

            while (_wavesController.AreWavesRemaining())
            {
                _wavesController.StartNextWave();
                yield return waitBetweenWaves;
            }
        }
    }
}
