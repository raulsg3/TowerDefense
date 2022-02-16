using UnityEngine;

namespace TowerDefense
{
    public static class FindUtils
    {
        public static GameObject FindClosestGameObject(GameObject[] objects, Vector3 position)
        {
            GameObject closest = null;
            float closestSqrDistance = Mathf.Infinity;

            foreach (GameObject obj in objects)
            {
                Vector3 distance = obj.transform.position - position;
                float sqrDistance = distance.sqrMagnitude;

                if (sqrDistance < closestSqrDistance)
                {
                    closest = obj;
                    closestSqrDistance = sqrDistance;
                }
            }

            return closest;
        }
    }
}
