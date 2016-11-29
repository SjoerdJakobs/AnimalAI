using UnityEngine;
using System.Collections;

public class PointLineUnit : MonoBehaviour {

    [SerializeField]
    private Transform target;

    private PointLinePathfinding pathing;
	// Use this for initialization
	void Start () {
        pathing = GetComponent<PointLinePathfinding>();
        pathing.PathDestination(target.position);
        pathing.StartPath();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
