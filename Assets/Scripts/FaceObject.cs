using UnityEngine;

public class FaceObject : MonoBehaviour
{
    public Transform target; // The target the object should face

    void Update()
    {
        if (target != null)
        {
            // Rotate this object to face the target
            transform.LookAt(target);
        }
    }
}
