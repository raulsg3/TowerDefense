using UnityEngine;

namespace TowerDefense
{
    public class TurretSurface : MonoBehaviour
    {
        [SerializeField]
        private GameObject _placeholderTurretPrefab;

        private GameObject _placeholderTurret;
        private Renderer _placeholderTurretRenderer;

        private void Start()
        {
            ServiceLocatorSingleton.Instance.GetService<IEventService>().OnTurretPlacingActivated += ActivateTurretSurface;
            ServiceLocatorSingleton.Instance.GetService<IEventService>().OnTurretPlacingDeactivated += DeactivateTurretSurface;

            DeactivateTurretSurface();
        }

        private void OnDestroy()
        {
            ServiceLocatorSingleton.Instance.GetService<IEventService>().OnTurretPlacingActivated -= ActivateTurretSurface;
            ServiceLocatorSingleton.Instance.GetService<IEventService>().OnTurretPlacingDeactivated -= DeactivateTurretSurface;
        }

        private void OnMouseEnter()
        {
            if (enabled)
                EnablePlaceholderTurretRenderer();
        }

        private void OnMouseOver()
        {
            if (enabled)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit raycastHit;

                if (Physics.Raycast(ray, out raycastHit, 100f))
                {
                    if (raycastHit.transform.gameObject == this.gameObject)
                    {
                        Vector3 placeholderTurretPosition = raycastHit.point;
                        placeholderTurretPosition.y = _placeholderTurret.transform.position.y;

                        _placeholderTurret.transform.position = placeholderTurretPosition;

                    }
                }

                if (Input.GetMouseButtonDown(0))
                {
                    ServiceLocatorSingleton.Instance.GetService<IEventService>().TurretPositionChosen(_placeholderTurret.transform.position);
                }
            }
        }

        private void OnMouseExit()
        {
            if (enabled)
                DisablePlaceholderTurretRenderer();
        }

        private void ActivateTurretSurface(Turret.EType turretType)
        {
            enabled = true;

            _placeholderTurret = Instantiate(_placeholderTurretPrefab);
            _placeholderTurretRenderer = _placeholderTurret.GetComponent<Renderer>();
        }

        private void DeactivateTurretSurface()
        {
            enabled = false;

            _placeholderTurretRenderer = null;

            if (_placeholderTurret != null)
            {
                Destroy(_placeholderTurret);
                _placeholderTurret = null;
            }
        }

        private void EnablePlaceholderTurretRenderer()
        {
            _placeholderTurretRenderer.enabled = true;
        }

        private void DisablePlaceholderTurretRenderer()
        {
            _placeholderTurretRenderer.enabled = false;
        }
    }
}
