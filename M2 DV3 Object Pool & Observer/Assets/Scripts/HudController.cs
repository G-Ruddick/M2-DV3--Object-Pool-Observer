using UnityEngine;

namespace Chapter.Observer {
    public class HUDController : Observer {
        private bool isTurnboOn;
        private float currentHealth;
        private BikeController bikeController;

        private void OnGUI() {
            GUILayout.BeginArea(new Rect(50, 50, 100, 200));
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("Health: " + currentHealth);
            GUILayout.EndHorizontal();

            if (isTurnboOn) {
                GUILayout.BeginHorizontal("box");
                GUILayout.Label("Turbo Activated!");
                GUILayout.EndHorizontal();
            }

            if (currentHealth <= 50.0f) {
                GUILayout.BeginHorizontal("box");
                GUILayout.Label("Warning: Low Health");
                GUILayout.EndHorizontal();
            }

            GUILayout.EndArea();
        }

        public override void Notify(Subject subject) {
            if (!bikeController) {
                bikeController = subject.GetComponent<BikeController>();
            }

            if (bikeController) {
                isTurnboOn = bikeController.IsTurboOn;
                currentHealth = bikeController.CurrentHealth;
            }
        }
    }
}