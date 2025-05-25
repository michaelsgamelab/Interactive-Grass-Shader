using UnityEngine;
using System.Collections.Generic;

public class Grass : MonoBehaviour
{
    Material grassMat;
    public MeshRenderer meshRenderer;
    List<Transform> entities = new List<Transform>();
    //bool emptyList = true;

    private void Awake()
    {
        grassMat = meshRenderer.material;
    }

    private void FixedUpdate()
    {
        if (entities.Count <= 0)
        {
            /*if (!emptyList)
            {
                grassMat.SetVector("_Pos", new Vector3(0f, 1000f, 0f));
                emptyList = true;
            }*/
            return;
        }
        grassMat.SetVector("_Pos", entities[entities.Count - 1].position);
    }

    private void OnTriggerEnter(Collider other)
    {
        entities.Add(other.transform);
        //emptyList = false;
    }

    private void OnTriggerExit(Collider other)
    {
        entities.Remove(other.transform);
    }
}
