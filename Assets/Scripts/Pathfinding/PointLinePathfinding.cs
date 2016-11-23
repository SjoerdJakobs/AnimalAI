using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PointLinePathfinding : MonoBehaviour {

    /// <summary>
    /// this is a pathfinding script that makes a line to the target on 0y.
    /// then it shoots a raycast on each line point to get the height of the point and if it is walkable.
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
    private bool outoBrake;
    public bool _outoBrake
    {
        get { return outoBrake; }
        set { outoBrake = value; }
    }
        [SerializeField]
    private bool showPathInEditor;      //set this bool true to see the path of the object in the editor.
        [SerializeField]
    private bool debugMode;             //set this bool true to activate debug mode wich lets pieces of code print to check if things work.

    private Stack<Vector3> waypoints;
    
    #endregion

    #region Functions

    #region Callfunctions
    /// <summary>
    /// set the target for your pathfinding
    /// </summary>
    /// <param name="target">the position of your destination</param>
    public void PathDestination(Vector3 target)
    {

        if (debugMode)
        {
            print("path destination recieved reached. target pos is: " + target);
        }
    }
    /// <summary>
    /// create and follow a path
    /// </summary>
    public void StartPath()
    {

        if (debugMode)
        {
            print("StartPath reached");
        }
    }
    /// <summary>
    /// stop on your path and stand still
    /// </summary>
    public void StopPath()
    {

        if(debugMode)
        {
            print("StopPath reached");
        }
    }
    /// <summary>
    /// assuming that you dont have a object with its pivot point at its bottom, this checks the distance between the ground and the pivot point.
    /// </summary>
    public void RecalculateHeight()
    {

        if (debugMode)
        {
            print("RecalculateHeight reached");
        }
    }
    #endregion

    #region PrivateFunctions
    /// <summary>
    /// this funtion creates the actual path.
    /// </summary>
    void CreatePath(Vector3 target)
    {
        Vector3 direct = (transform.position - new Vector3(target.x,transform.position.y,target.z)).normalized;
        for (int i = 1; i < (pathingRange / spaceBetweenPoints) + 1;)
        {
            RaycastHit hit;
            Vector3 waypoint = direct * i;
            if (Physics.Raycast(waypoint, Vector3.down, out hit,100,walkableMask, QueryTriggerInteraction.Ignore))
            {

                if (debugMode)
                {
                    print("hit a walkable object - distance: " + hit.distance);
                }
            }
            else
            {

            }
            print("reached for loop");
        }
    }
    #endregion

    #endregion
}
