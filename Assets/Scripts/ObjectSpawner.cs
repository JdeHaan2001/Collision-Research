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
}
