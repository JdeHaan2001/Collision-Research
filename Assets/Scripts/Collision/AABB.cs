using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AABB : Collision
{
    public override bool IsColliding(Collision a, Collision b)
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
