using UnityEngine;

namespace TowerDefense
{
    public class TurretSurface : MonoBehaviour
    {
        private void Start()
        {
            EventManagerSingleton.Instance.OnSetTurretPlacing += EnableTurretSurface;
        }

        private void OnDestroy()
        {
            EventManagerSingleton.Instance.OnSetTurretPlacing -= EnableTurretSurface;
        }

        private void OnMouseOver()
        {
            if (enabled)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit raycastHit;

                    if (Physics.Raycast(ray, out raycastHit, 100f))
                    {
                        if (raycastHit.collider.CompareTag(Tags.Ground))
                        {
                            EventManagerSingleton.Instance.TurretPositionChosen(raycastHit.point);
                        }
                    }
                }
            }
        }

        private void EnableTurretSurface(bool enable)
        {
            enabled = enable;
        }
    }
}
