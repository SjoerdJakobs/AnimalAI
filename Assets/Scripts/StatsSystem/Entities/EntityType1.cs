using UnityEngine;
using System.Collections;

public class EntityType1 : Animal
{
    [SerializeField]
    private EntityBehaviour entityBehaviour;
    [SerializeField]
    private Priorities priorities;

    public EntityStats getEntityStats
    {
        get { return entityStats; }
        set { entityStats = value; }
    }

    public AnimalStats getAnimalStats
    {
        get { return animalStats; }
        set { animalStats = value; }
    }

    private ScriptAndPointsHandler scriptAndPointsHandler;

    // Use this for initialization
    override protected void Awake()
    {
        base.Awake();
        scriptAndPointsHandler = GetComponent<ScriptAndPointsHandler>();
        //priorities = new Priorities();
    }

    override protected void Start()
    {
        base.Start();
        StartCoroutine(SlowUpdate());
        //print("startEntity");
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

            scriptAndPointsHandler.inputValue(1, priorities.food);
            //print(priorities.food);
            scriptAndPointsHandler.inputValue(2, priorities.sleep);

            yield return new WaitForSeconds(0.1f);
        }
    }

    void calculatePriorities()
    {
        priorities.food = animalStats.maxHunger / animalStats.hunger * animalStats.maxHunger; 
        priorities.sleep = animalStats.maxStamina - animalStats.stamina;
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
