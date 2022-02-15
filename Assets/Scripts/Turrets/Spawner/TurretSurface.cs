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
            EventManagerSingleton.Instance.OnSetTurretPlacing += EnableTurretSurface;

            _placeholderTurret = Instantiate(_placeholderTurretPrefab);
            _placeholderTurretRenderer = _placeholderTurret.GetComponent<Renderer>();
        }

        private void OnDestroy()
        {
            EventManagerSingleton.Instance.OnSetTurretPlacing -= EnableTurretSurface;
        }

        private void OnMouseEnter()
        {
            if (enabled)
                EnablePlaceholderTurretRenderer(true);
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
                    EventManagerSingleton.Instance.TurretPositionChosen(_placeholderTurret.transform.position);
                }
            }
        }

        private void OnMouseExit()
        {
            if (enabled)
                EnablePlaceholderTurretRenderer(false);
        }

        private void EnableTurretSurface(bool enable)
        {
            enabled = enable;
            EnablePlaceholderTurretRenderer(enable);
        }

        private void EnablePlaceholderTurretRenderer(bool enable)
        {
            _placeholderTurretRenderer.enabled = enable;
        }
    }
}
