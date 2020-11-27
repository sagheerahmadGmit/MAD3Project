using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EndlessLevel : MonoBehaviour
{
    public List<GameObject> roads;
    public float offset = 243.8652f;

    void Start()
    {
        if (roads != null && roads.Count < 0) {
            roads = roads.OrderBy(r => r.transform.position.z).ToList();
        }
    }

    public void MoveRoad() {
        GameObject moveRoad = roads[0];
        roads.Remove(moveRoad);
        float newZ = roads[roads.Count - 1].transform.position.z + offset;
        moveRoad.transform.position = new Vector3(-28.29995f, -85.80732f, newZ);
        roads.Add(moveRoad);
    }
}

