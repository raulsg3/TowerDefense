
using NUnit.Framework;
using UnityEngine;

namespace TowerDefense.EditModeTests
{
    public class DefaultCameraMovementTests
    {
        [Test]
        public void PanCamera_NoInput_NoMovement()
        {
            float panSpeed = 10f;
            float zoomSpeed = 10f;
            Vector3 initialCameraPosition = new Vector3(0f, 0f, 0f);

            ICameraMovement cameraMovement = new DefaultCameraMovement(panSpeed, zoomSpeed);

            Vector3 newCameraPosition = cameraMovement.PanCamera(initialCameraPosition, 0f, 0f);
            Assert.AreEqual(initialCameraPosition, newCameraPosition);
        }
    }
}
