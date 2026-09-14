using UnityEngine;

namespace Chapter.Observer {
    public class CameraController : Observer {
        private bool isTurnboOn;
        private Vector3 initialPosition;
        private float shakeMagnitude = 0.1f;

        private BikeController bikeController;

        private void OnEnable() {
            initialPosition = gameObject.transform.localPosition;
        }

        private void Update() {
            if (isTurnboOn) {
                gameObject.transform.localPosition = initialPosition + (Random.insideUnitSphere * shakeMagnitude);
            }

            else {
                gameObject.transform.localPosition = initialPosition;
            }
        }

        public override void Notify(Subject subject) {
            if (!bikeController) {
                bikeController = subject.GetComponent<BikeController>();
            }
            if (bikeController) {
                isTurnboOn = bikeController.IsTurboOn;
            }
        }
    }
}