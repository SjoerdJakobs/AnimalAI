using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public static class CalculatePath
{

	public static Vector3[] CreatePath(this Transform t ,Vector3 target, float pathingRange, float spaceBetweenPoints, LayerMask walkableMask,  bool debugMode = false)
    {
        List<Vector3> waypoints = new List<Vector3>();
        Vector3 direct = (t.position - new Vector3(target.x, t.position.y, target.z)).normalized;
        
        for (int i = 0; i < (pathingRange / spaceBetweenPoints); i++)
        {
            RaycastHit hit;
            Vector3 waypoint = (direct * (spaceBetweenPoints * (i + 1))) + new Vector3(0, 50, 0);
            if (Physics.Raycast(waypoint, Vector3.down, out hit, 100))
            {
                if (hit.transform.gameObject.layer == walkableMask)
                {
                    waypoints[i] = hit.point;
                    Debug.Assert(!debugMode, "hit a walkable object - hit pos: " + hit.point + " rayNr: " + i);
                }
                else
                {

                    Debug.Assert(!debugMode, "hit a unwalkable walkable object - hit pos: " + hit.point + " hit object name: " + hit.collider.gameObject + " rayNr: " + i);
                }
            }
            else
            {
                Debug.Assert(!debugMode, "no object that is 50 units higher or lower than the pathfinding object" + " rayNr: " + i);
            }
            Debug.Assert(!debugMode, "reached for loop");
        }
        return (waypoints.ToArray());
    }
}
