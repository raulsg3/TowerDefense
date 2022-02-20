namespace TowerDefense
{
    public interface IWavesController
    {
        public int GetCurrentWaveNumber();

        public int GetNumWaves();

        public bool AreWavesRemaining();

        public void StartNextWave();

        public bool IsCurrentWaveSpawning();
    }
}
