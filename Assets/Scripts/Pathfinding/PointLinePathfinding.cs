using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PointLinePathfinding : MonoBehaviour {

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
    private List<Vector3> waypoints;    //in this list are the positions that the pathfinding wil use for navigation.
    //private bool hasTarget;             //this bool is used to check if there is a target to walk to.
    
    #endregion

    void Start()
    {
        CreatePath(pathingTarget);
        waypoints = new List<Vector3>();
        StartCoroutine(RefreshPath());
        //Vector3 target = new Vector3(1,2,3);
        print("halp");
        //Debug.Assert(!debugMode, "target recieved reached. target pos is: " + target);
    }

    #region Functions

    #region Callfunctions
    /// <summary>
    /// set the target for your pathfinding
    /// </summary>
    /// <param name="target">the position of your destination</param>
    public void PathDestination(Vector3 target)
    {
        Debug.Assert(!debugMode,"target recieved reached. target pos is: " + target);
        
        RaycastHit hit;
        if (Physics.Raycast((target + new Vector3(0, 50, 0)), Vector3.down, out hit, 100, walkableMask, QueryTriggerInteraction.Ignore))
        {
            pathingTarget = hit.point;
            //hasTarget = true;
            Debug.Assert(!debugMode, "path destination set. pathing target pos is: " + pathingTarget.normalized);
            
        }
        else
        {
            Debug.Assert(!debugMode, "target isnt at a walkable place");
        }
    }
    /// <summary>
    /// create and follow a path
    /// </summary>
    public void StartPath()
    {
        StartCoroutine(FollowPath());
        Debug.Assert(!debugMode, "StartPath reached");
        
    }
    /// <summary>
    /// stop on your path and stand still
    /// </summary>
    public void StopPath()
    {

        Debug.Assert(!debugMode, "StopPath reached");
        
    }
    /// <summary>
    /// assuming that you dont have a object with its pivot point at its bottom, this checks the distance between the ground and the pivot point.
    /// </summary>
    public void RecalculateHeight()
    {

        Debug.Assert(!debugMode, "RecalculateHeight reached");        
    }
    #endregion

    #region PrivateFunctions
    /// <summary>
    /// this funtion creates the actual path.
    /// </summary>
    void CreatePath(Vector3 target)
    {
        Vector3 direct = (transform.position - new Vector3(target.x,transform.position.y,target.z)).normalized;
        print(direct);
        for (int i = 0; i < (pathingRange / spaceBetweenPoints); i++)
        {
            RaycastHit hit;
            Vector3 waypoint = (direct *(spaceBetweenPoints * (i+1)))+new Vector3(0,50,0);
            if (Physics.Raycast(waypoint, Vector3.down, out hit,100))
            {
                if (hit.transform.gameObject.layer != walkableMask)
                {
                    waypoints[i] = hit.point;
                    Debug.Assert(!debugMode, "hit a walkable object - hit pos: " + hit.point + " rayNr: " + i);
                }
                else
                {
                    
                    Debug.Assert(!debugMode, "hit a unwalkable walkable object - hit pos: " + hit.point + " hit object name: " + hit.collider.gameObject +" rayNr: " + i);
                }        
            }
            else
            {
                Debug.Assert(!debugMode, "no object that is 50 units higher or lower than the pathfinding object" + " rayNr: " + i);                
            }
            Debug.Assert(!debugMode, "reached for loop");           
        }
    }

    IEnumerator RefreshPath()
    {
        while(true)
        {
            targetNr = 0;
            CreatePath(pathingTarget);
            yield return new WaitForSeconds(refreshRate);
        }
    }

    /// <summary>
    /// this coroutine makes the object move. it gets the list of waypoints and lets the object go from waypoint to waypoint.
    /// the object moves here without physics and physics wont work with this type of movement.
    /// </summary>
    IEnumerator FollowPath()
    {
        Debug.Assert(!debugMode, "reached FollowPath");
        
        if (waypoints.Count >= 1)
        {
            Debug.Assert(!debugMode, "recieved waypoints");
            
            Vector3 currentWaypoint = waypoints[0];

            while (true)
            {
                if (transform.position == currentWaypoint)
                {
                    targetNr++;
                    if (targetNr >= waypoints.Count)

                    {
                        Debug.Assert(!debugMode, "at target destination");
                        //hasTarget = false;
                        yield break;
                    }

                    currentWaypoint = waypoints[targetNr];
                }

                transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, movementSpeed * Time.deltaTime);
                yield return null;
            }
        }
        else
        { 
            Debug.Assert(!debugMode, "no waypoints");
        }
    }

    public void OnDrawGizmos()
    {
        if (showPathInEditor)
        {
            for (int i = targetNr; i < waypoints.Count; i++)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawCube(waypoints[targetNr], Vector3.one);

                if (i == targetNr)
                {
                    Gizmos.DrawLine(transform.position, waypoints[targetNr]);
                }
                else
                {
                    Gizmos.DrawLine(waypoints[targetNr - 1], waypoints[targetNr]);
                }
            }
        }
    }
    #endregion

    #endregion
}
