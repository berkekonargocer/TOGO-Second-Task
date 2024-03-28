using UnityEngine;


    public class Item : MonoBehaviour, IPickable
    {
        [field: SerializeField] Color ItemColor { get; set; }

        public void Pickup(Transform parent) {
            SetParent(parent);
        }

        private void Awake() {
            gameObject.GetComponent<Renderer>().material.color = ItemColor;
        }

        Transform GetTransform() {
            return gameObject.transform;
        }

        void SetParent(Transform parent) {
            gameObject.transform.parent = parent;
        }
    } 