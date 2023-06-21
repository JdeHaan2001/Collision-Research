using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    Cube = 0, Sphere
};

public enum CollisionType
{
    CustomAABB = 0, CustomSphere, UnityBoxCollider, UnitySphereCollider
};

public class ObjectSpawner : MonoBehaviour
{
    public ObjectType ObjType;
    public CollisionType CollisionType;
    public int AmountOfObjects;

    private void Start()
    {
        GameObject parent = new GameObject("Objects");
        parent.transform.position = Vector3.zero;

        if (AmountOfObjects > 0)
        {
            if (ObjType == ObjectType.Cube)
                SpawnObjects(PrimitiveType.Cube, parent.transform);
            else
                SpawnObjects(PrimitiveType.Sphere, parent.transform);
        }
    }

    private void SpawnObjects(PrimitiveType pType, Transform pParent)
    {
        if (CollisionType == CollisionType.CustomAABB)
        {
            for (int i = 0; i < AmountOfObjects; i++)
            {
                GameObject obj = GameObject.CreatePrimitive(pType);
                obj.transform.parent = pParent;

                Destroy(obj.GetComponent<Collider>());
                obj.AddComponent<AABB>();
            }
        }
        else if (CollisionType == CollisionType.CustomSphere)
        {
            for (int i = 0; i < AmountOfObjects; i++)
            {
                GameObject obj = GameObject.CreatePrimitive(pType);
                obj.transform.parent = pParent;

                Destroy(obj.GetComponent<Collider>());
                obj.AddComponent<CircleCollision>();
            }
        }
        else
        {
            for (int i = 0; i < AmountOfObjects; i++)
            {
                GameObject obj = GameObject.CreatePrimitive(pType);
                obj.transform.parent = pParent;
            }
        }
    }
}
