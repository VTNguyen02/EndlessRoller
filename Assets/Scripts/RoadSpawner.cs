using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using NUnit.Framework;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public List<GameObject> roads;
    private float offset = 40f;
    void Start()
    {
        if (roads != null && roads.Count > 0)
        {
            roads = roads.OrderBy(r => r.transform.position.z).ToList();
        }
    }
  
    public void MoveRoad()
    {
        Debug.Log("Road Spawn");
        GameObject movedRoad = roads[0];
        roads.Remove(movedRoad);
        float newZ = roads[roads.Count - 1].transform.position.z + offset;
        movedRoad.transform.position = new Vector3(0, 0, newZ);
        roads.Add(movedRoad);
    }
}
