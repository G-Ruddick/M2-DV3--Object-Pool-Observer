using UnityEngine;

namespace Chapter.ObjectPool {
    public class ClientObjectPool : MonoBehaviour {
        private DroneObjectPool pool;

        void Start() {
            pool = gameObject.AddComponent<DroneObjectPool>();
        }

        void OnGUI() {
            GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();

            if (GUILayout.Button("Spawn Drones")) {
                pool.Spawn();
            }

            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
            GUILayout.EndArea();
        }
    }
}
