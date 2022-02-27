
using NUnit.Framework;
using UnityEngine;

namespace TowerDefense.EditModeTests
{
    public class DefaultCameraMovementTests
    {
        readonly float _panSpeed = 10f;
        readonly float _zoomSpeed = 10f;
        readonly Vector3 _initialCameraPosition = new Vector3(0f, 0f, 0f);

        ICameraMovement _cameraMovement = null;

        [SetUp]
        public void SetUp()
        {
            _cameraMovement = new DefaultCameraMovement(_panSpeed, _zoomSpeed);
        }

        [Test]
        public void PanCamera_NoInput_NoMovement()
        {
            Vector3 newCameraPosition = _cameraMovement.PanCamera(_initialCameraPosition, 0f, 0f);

            Assert.AreEqual(_initialCameraPosition, newCameraPosition);
        }

        [TestCase(100f, 100f)]
        [TestCase(0.001f, 0.05f)]
        [TestCase(1f, 5f)]
        public void PanCamera_PositiveInput_PositiveMovement(float xInput, float zInput)
        {
            Vector3 newCameraPosition = _cameraMovement.PanCamera(_initialCameraPosition, xInput, zInput);

            Assert.AreEqual(_initialCameraPosition.x + xInput * _panSpeed, newCameraPosition.x);
            Assert.Greater(newCameraPosition.x, _initialCameraPosition.x);

            Assert.AreEqual(_initialCameraPosition.z + zInput * _panSpeed, newCameraPosition.z);
            Assert.Greater(newCameraPosition.z, _initialCameraPosition.z);
        }

        [TestCase(-100f, -100f)]
        [TestCase(-0.001f, -0.05f)]
        public void PanCamera_NegativeInput_NegativeMovement(float xInput, float zInput)
        {
            Vector3 newCameraPosition = _cameraMovement.PanCamera(_initialCameraPosition, xInput, zInput);

            Assert.AreEqual(_initialCameraPosition.x + xInput * _panSpeed, newCameraPosition.x);
            Assert.Less(newCameraPosition.x, _initialCameraPosition.x);

            Assert.AreEqual(_initialCameraPosition.z + zInput * _panSpeed, newCameraPosition.z);
            Assert.Less(newCameraPosition.z, _initialCameraPosition.z);
        }

        [Test]
        public void ZoomCamera_NoInput_NoMovement()
        {
            Vector3 newCameraPosition = _cameraMovement.ZoomCamera(_initialCameraPosition, 0f);

            Assert.AreEqual(_initialCameraPosition, newCameraPosition);
        }

        [TestCase(100f)]
        [TestCase(0.001f)]
        public void ZoomCamera_PositiveInput_NegativeMovement(float yInput)
        {
            Vector3 newCameraPosition = _cameraMovement.ZoomCamera(_initialCameraPosition, yInput);

            Assert.AreEqual(_initialCameraPosition.y - yInput * _zoomSpeed, newCameraPosition.y);
            Assert.Less(newCameraPosition.y, _initialCameraPosition.y);
        }

        [TestCase(-50f)]
        [TestCase(-0.005f)]
        public void ZoomCamera_NegativeInput_PositiveMovement(float yInput)
        {
            Vector3 newCameraPosition = _cameraMovement.ZoomCamera(_initialCameraPosition, yInput);

            Assert.AreEqual(_initialCameraPosition.y - yInput * _zoomSpeed, newCameraPosition.y);
            Assert.Greater(newCameraPosition.y, _initialCameraPosition.y);
        }
    }
}
