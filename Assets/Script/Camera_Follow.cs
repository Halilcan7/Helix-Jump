using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
   [SerializeField] private Transform target;
   private Vector3 offset;

   private void Start() {
    offset = transform.position - target.position;
   }

   private void LateUpdate() {
    var current = offset + target.position;

    if(current.y > transform.position.y) 
    {
        return;
    }
    transform.position = current;
   }
}
