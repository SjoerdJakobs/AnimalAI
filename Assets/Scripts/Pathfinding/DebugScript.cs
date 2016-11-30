using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DebugScript : MonoBehaviour
{

    /// <summary>
    /// this is a pathfinding class that makes a line to the target ignoring the height value.
    /// It shoots a raycast on each line point to get the height of the point and if it is walkable.
    /// </summary>

    #region Variables
    [SerializeField]                //this value is used for the speed the pathfinder wil move the object.
    private float movementSpeed;
    public float _movementSpeed
    {
        get { return movementSpeed; }
        set { movementSpeed = value; }
    }
    [SerializeField]                //this is value is used for the radius that the pathfinder wil use object detection and evasion.
    private float pathingRange;
    public float _pathingRange
    {
        get { return pathingRange; }
        set { pathingRange = value; }
    }
    [SerializeField]
    private float refreshRate;          //this value is used for the time between refreshes of the path.
    public float _refreshRate
    {
        get { return refreshRate; }
        set { refreshRate = value; }
    }
    [SerializeField]
    private float spaceBetweenPoints;   //this value wil be used for the distance between points.
    public float _spaceBetweenPoints
    {
        get { return spaceBetweenPoints; }
        set { spaceBetweenPoints = value; }
    }
    [SerializeField]
    private LayerMask walkableMask;  //all the layermasks in here wil be seen as mesh that can be walked on.
    [SerializeField]
    private bool usePhysics;            //set this bool true if you want to use physics.
    public bool _usePhysics
    {
        get { return usePhysics; }
        set { usePhysics = value; }
    }
    [SerializeField]                //set this bool true to activate outobraking when near its target
    private bool autoBrake;
    public bool _autoBrake
    {
        get { return autoBrake; }
        set { autoBrake = value; }
    }
    [SerializeField]
    private bool showPathInEditor;      //set this bool true to see the path of the object in the editor.
    [SerializeField]
    private bool debugMode;             //set this bool true to activate debug mode, to check if things work.

    private int targetNr;               //this is used to count up in following the path and can be set to 0 for a new path
    private Vector3 pathingTarget;      //this is the position the pathfinding wil go to.
    private Vector3[] path;             //in this list are the positions that the pathfinding wil use for navigation.
    private bool hasTarget;             //this bool is used to check if there is a target to walk to.
    private bool hasPath;
    private bool shouldMove;
    #endregion


    void CreatePath(Vector3 startPos, Vector3 target, int pathingRange, float spaceBetweenPoints)
    {
        List<Vector3> calculatedPath = new List<Vector3>();
        Vector3 direct = (startPos - new Vector3(target.x, startPos.y, target.z)).normalized;
        for (int i = 0; i < (pathingRange / spaceBetweenPoints); i++)
        {
            RaycastHit hit;
            Vector3 waypoint = (direct * (spaceBetweenPoints * (i + 1))) + new Vector3(0, 50, 0);
            if (Physics.Raycast(waypoint, Vector3.down, out hit, 100))
            {
                if (hit.transform.gameObject.layer != walkableMask)
                {
                    calculatedPath[i] = hit.point;
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
        path = calculatedPath.ToArray();
        hasPath = true;
    }
}
