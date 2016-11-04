using UnityEngine;
using System.Collections;

public class GetFoodFromPlant : BehaveScript {

    [SerializeField]
    private LayerMask trees;
    private NavMeshAgent agent;
    private GameObject target;

    private bool hasTarget = false;
    private float radius = 5;


    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    //this will run once when the script epened
    override protected void OpenBehaviour()
    {
        base.OpenBehaviour();
        print("Open");
    }

    //this will run every 0.1 seconds
    override protected void Behaviour()
    {
        base.Behaviour();
        if (!hasTarget)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, trees);
            if(hitColliders[0] != null)
            {
                target = hitColliders[0].gameObject;
                hasTarget = true;
            }
            else
            {
                radius += 0.5f;
            }
        }
        else
        {
            agent.SetDestination(target.transform.position);
        }
        print("test");
    }

    //this will run once when this script is closed
    override protected void CloseBehaviour()
    {
        base.CloseBehaviour();
        agent.Stop();
        radius = 5;
        print("Close");
    }
}
