
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

        [TestCase(100f, 100f)]
        [TestCase(0.001f, 0.05f)]
        [TestCase(1f, 5f)]
        public void PanCamera_PositiveInput_PositiveMovement(float xInput, float zInput)
        {
            float panSpeed = 10f;
            float zoomSpeed = 10f;
            Vector3 initialCameraPosition = new Vector3(0f, 0f, 0f);

            ICameraMovement cameraMovement = new DefaultCameraMovement(panSpeed, zoomSpeed);
            Vector3 newCameraPosition = cameraMovement.PanCamera(initialCameraPosition, xInput, zInput);

            Assert.AreEqual(initialCameraPosition.x + xInput * panSpeed, newCameraPosition.x);
            Assert.Greater(newCameraPosition.x, initialCameraPosition.x);

            Assert.AreEqual(initialCameraPosition.z + zInput * panSpeed, newCameraPosition.z);
            Assert.Greater(newCameraPosition.z, initialCameraPosition.z);
        }

        [TestCase(-100f, -100f)]
        [TestCase(-0.001f, -0.05f)]
        public void PanCamera_NegativeInput_NegativeMovement(float xInput, float zInput)
        {
            float panSpeed = 10f;
            float zoomSpeed = 10f;
            Vector3 initialCameraPosition = new Vector3(0f, 0f, 0f);

            ICameraMovement cameraMovement = new DefaultCameraMovement(panSpeed, zoomSpeed);
            Vector3 newCameraPosition = cameraMovement.PanCamera(initialCameraPosition, xInput, zInput);

            Assert.AreEqual(initialCameraPosition.x + xInput * panSpeed, newCameraPosition.x);
            Assert.Less(newCameraPosition.x, initialCameraPosition.x);

            Assert.AreEqual(initialCameraPosition.z + zInput * panSpeed, newCameraPosition.z);
            Assert.Less(newCameraPosition.z, initialCameraPosition.z);
        }

        [Test]
        public void ZoomCamera_NoInput_NoMovement()
        {
            float panSpeed = 10f;
            float zoomSpeed = 10f;
            Vector3 initialCameraPosition = new Vector3(0f, 0f, 0f);

            ICameraMovement cameraMovement = new DefaultCameraMovement(panSpeed, zoomSpeed);
            Vector3 newCameraPosition = cameraMovement.ZoomCamera(initialCameraPosition, 0f);

            Assert.AreEqual(initialCameraPosition, newCameraPosition);
        }

        [TestCase(100f)]
        [TestCase(0.001f)]
        public void ZoomCamera_PositiveInput_NegativeMovement(float yInput)
        {
            float panSpeed = 10f;
            float zoomSpeed = 10f;
            Vector3 initialCameraPosition = new Vector3(0f, 0f, 0f);

            ICameraMovement cameraMovement = new DefaultCameraMovement(panSpeed, zoomSpeed);
            Vector3 newCameraPosition = cameraMovement.ZoomCamera(initialCameraPosition, yInput);

            Assert.AreEqual(initialCameraPosition.y - yInput * zoomSpeed, newCameraPosition.y);
            Assert.Less(newCameraPosition.y, initialCameraPosition.y);
        }

        [TestCase(-50f)]
        [TestCase(-0.005f)]
        public void ZoomCamera_NegativeInput_PositiveMovement(float yInput)
        {
            float panSpeed = 10f;
            float zoomSpeed = 10f;
            Vector3 initialCameraPosition = new Vector3(0f, 0f, 0f);

            ICameraMovement cameraMovement = new DefaultCameraMovement(panSpeed, zoomSpeed);
            Vector3 newCameraPosition = cameraMovement.ZoomCamera(initialCameraPosition, yInput);

            Assert.AreEqual(initialCameraPosition.y - yInput * zoomSpeed, newCameraPosition.y);
            Assert.Greater(newCameraPosition.y, initialCameraPosition.y);
        }
    }
}
