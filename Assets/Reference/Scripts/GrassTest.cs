using UnityEngine;

public class GrassTest : MonoBehaviour
{
    bool canRotate = false;
    Transform dirTransform;

    private void FixedUpdate()
    {
        if (!canRotate) return;
        if (dirTransform == null) return;
        Vector3 Dir = dirTransform.position - transform.position;

        Vector3 temp = Dir;

        Dir.y = 0;
        Dir.x = -temp.z;
        Dir.z = temp.x;

        float distance = Vector3.Distance(transform.position, dirTransform.position);

        Quaternion targetRot = Quaternion.AngleAxis(180f / (distance * distance), Dir.normalized);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, .33f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GrassCollider"))
        {
            canRotate = true;
            dirTransform = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("GrassCollider"))
        {
            canRotate = false;
            dirTransform = null;
            transform.rotation = Quaternion.identity;
        }
    }
}
