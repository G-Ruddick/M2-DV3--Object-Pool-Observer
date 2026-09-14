using UnityEngine;
using UnityEngine.Pool;
using System.Collections;

namespace Chapter.ObjectPool {
    public class Drone : MonoBehaviour {
        public IObjectPool<Drone> Pool {
            get;
            set;
        }

        public float currentHealth;

        [SerializeField] 
        private float maxHealth = 100.0f;

        [SerializeField]
        private float timeToSelfDestruct = 3.0f;

        void Start() {
            currentHealth = maxHealth;
        }

        private void OnEnable() {
            AttackPlayer();
            StartCoroutine(SelfDestruct());
        }

        private void OnDisable() {
            ResetDrone();
        }

        IEnumerator SelfDestruct() {
            yield return new WaitForSeconds(timeToSelfDestruct);
            TakeDamage(maxHealth);
        }

        private void ReturnToPool() {
            Pool.Release(this);
        }

        private void ResetDrone() {
            currentHealth = maxHealth;
        }

        public void AttackPlayer() {
            Debug.Log("Attack Player!");
        }

        public void TakeDamage(float amount) {
            currentHealth -= amount;

            if (currentHealth <= 0.0f) {
                ReturnToPool();
            }
        }
    }
}
