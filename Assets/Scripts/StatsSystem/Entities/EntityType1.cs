using UnityEngine;
using System.Collections;

public class EntityType1 : LivingEntity
{
    [SerializeField]
    private EntityBehaviour entityBehaviour;
    [SerializeField]
    private Priorities priorities;
    private ScriptAndPointsHandler scriptAndPointsHandler;

    // Use this for initialization
    void Awake()
    {
        scriptAndPointsHandler = GetComponent<ScriptAndPointsHandler>();
        //priorities = new Priorities();
    }

    override protected void Start()
    {
        base.Start();
        StartCoroutine(SlowUpdate());
    }

    // Update is called once per frame
    override protected void Update()
    {
        base.Update();
        //scriptAndPointsHandler.inputValue(1, entityStats.health);
    }

    IEnumerator SlowUpdate()
    {
        while (true)
        {
            calculatePriorities();

            scriptAndPointsHandler.inputValue(3, priorities.food);
            //print(priorities.food);
            scriptAndPointsHandler.inputValue(1, priorities.sleep);

            yield return new WaitForSeconds(0.1f);
        }
    }

    void calculatePriorities()
    {
        priorities.food = entityStats.maxHunger / entityStats.hunger * entityStats.maxHunger; 
        priorities.sleep = entityStats.maxStamina - entityStats.stamina;
    }

    void setStats()
    {
        

    }
}

#region ENTITYBEHAVIOUR
[System.Serializable]
public class Priorities
{
    public float shelter = 0;
    public float safety = 0;
    public float food = 0;
    public float happy = 0;
    public float sleep = 0;
}

[System.Serializable]
public class EntityBehaviour
{
    public float aggresion = 1;
    public float carOmniHerbi = 0;
    public float brave = 1;
    public float lazyness = 1; 
}

#endregion
