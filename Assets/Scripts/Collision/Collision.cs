using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Collision : MonoBehaviour
{
    [HideInInspector]
    public Bounds objBounds { get; set; }
    [HideInInspector]
    public List<Collision> trackedColliders;

    private void Start()
    {
        objBounds = GetComponent<MeshRenderer>().bounds;
        var tempArray = (Collision[])GameObject.FindObjectsOfType(typeof(Collision));
        trackedColliders = tempArray.ToList();

        //Making sure it doesn't track itself
        if (trackedColliders.Contains(this))
            trackedColliders.Remove(this);
    }

    private void Update()
    {
        for (int i = 0; i < trackedColliders.Count; i++)
        {
            if (IsColliding(this, trackedColliders[i]))
                Debug.Log("Is Colliding");
        }
    }

    public virtual bool IsColliding(Collision a, Collision b)
    {
        Debug.LogWarning("Nothing is implemented, will always return false");
        return false;
    }
}
