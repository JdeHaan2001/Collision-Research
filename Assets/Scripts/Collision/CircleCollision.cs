using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCollision : Collision
{
    public override bool IsColliding(Collision a, Collision b)
    {
        Vector3 posA = a.transform.position;
        Vector3 posB = b.transform.position;

        Vector3 sizeA = a.objBounds.extents;
        Vector3 sizeB = b.objBounds.extents;

        Vector3 deltaVector = posB - posA;

        if (deltaVector.magnitude < sizeA.x + sizeB.x)
            return true;
        else
            return false;
    }
}
