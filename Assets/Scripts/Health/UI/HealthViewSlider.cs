using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    public class HealthViewSlider : IHealthView
    {
        [SerializeField]
        protected Slider _slider;

        public override void UpdateHealth(float value)
        {
            _slider.value = value;
        }
    }
}
