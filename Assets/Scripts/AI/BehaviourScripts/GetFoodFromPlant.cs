using UnityEngine;
using System.Collections;

public class GetFoodFromPlant : BehaveScript {

    [SerializeField]
    private LayerMask trees;
    private NavMeshAgent agent;
    private EntityType1 stats;
    private GameObject target;
    private IAmLiving tree;

    private bool hasTarget = false;
    private float radius = 10;


    void Awake()
    {
        stats = GetComponent<EntityType1>();
        agent = GetComponent<NavMeshAgent>();
    }

    //this will run once when the script epened
    override protected void OpenBehaviour()
    {
        base.OpenBehaviour();
        stats.getAnimalStats.getHungry = -0.1f;
        agent.ResetPath();
        //agent.Resume();
        radius = 10;
        print("Open" + scriptNR);
    }

    //this will run every 0.1 seconds
    override protected void Behaviour()
    {
        base.Behaviour();
        if (!hasTarget)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, trees);
            if (hitColliders.Length > 0)
            {
                target = hitColliders[0].gameObject;
                tree = target.GetComponent<IAmLiving>();
                hasTarget = true;
            }
            else
            {
                radius += 1;
                hasTarget = false;
            }
        }
        else
        {
            if (target != null)
            {
                stats.getAnimalStats.getHungry = -0.1f;
                if (Vector3.Distance(transform.position, target.transform.position) <= 1f)
                {
                    agent.speed = 0;
                    stats.getAnimalStats.getHungry = 0.5f;
                    tree.TakeDamage(0.1f);
                }
                else
                {
                    agent.speed = 5;
                    agent.SetDestination(target.transform.position);
                }
            }
            else
            {
                hasTarget = false;
                radius = 10;
            }
        }
        print("script"+scriptNR);
    }

    //this will run once when this script is closed
    override protected void CloseBehaviour()
    {
        base.CloseBehaviour();
        agent.Stop();
        stats.getAnimalStats.getHungry = -0.1f;
        radius = 10;
        print("Close" + scriptNR);
    }
}
