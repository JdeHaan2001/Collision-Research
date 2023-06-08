using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AABB : MonoBehaviour
{
    public AABB otherColider;

    [HideInInspector]
    public Bounds objBounds { get; set; }
    public List<AABB> trackedColliders;

    private void Start()
    {
        objBounds = GetComponent<MeshRenderer>().bounds;
        var tempArray = (AABB[]) GameObject.FindObjectsOfType(typeof(AABB));
        trackedColliders = tempArray.ToList();

        //Making sure it doesn't track itself
        if (trackedColliders.Contains(this))
        {
            trackedColliders.Remove(this);
        }
    }

    private void Update()
    {
        for (int i = 0; i < trackedColliders.Count; i++)
        {
            if (IsColliding(this, trackedColliders[i]))
                Debug.Log("Is Colliding");
        }
    }

    public bool IsColliding(AABB a, AABB b)
    {
        Vector3 posA = a.transform.position;
        Vector3 posB = b.transform.position;

        Vector3 sizeA = a.objBounds.size;
        Vector3 sizeB = b.objBounds.size;

        if (posA.x < posB.x + sizeB.x &&
            posA.x + sizeA.x > posB.x &&
            posA.y < posB.y + sizeB.y &&
            posA.y + sizeA.y > posB.y &&
            posA.z < posB.z + sizeB.z &&
            posA.z + sizeA.z > posB.z)
            return true;
        else
            return false;
    }
}
