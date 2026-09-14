using UnityEngine;

namespace Chapter.Observer {
    public class ClientObserver : MonoBehaviour {
        private BikeController bikeController;

        private void Start() {
            bikeController = (BikeController)FindAnyObjectByType(typeof(BikeController));
        }

        private void OnGUI() {
            if (GUILayout.Button("Damage Bike")) {
                if (bikeController) {
                    bikeController.TakeDamage(15.0f);
                }
            }

            if (GUILayout.Button("Toggle Turbo")) {
                if (bikeController) {
                    bikeController.ToggleTurbo();
                }
            }
        }
    }
}