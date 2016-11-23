using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LivingEntity : MonoBehaviour , IAmLiving
{
    [SerializeField]
    protected EntityStats entityStats;
    [SerializeField]
    protected Dictionary<string, float> entityStatsDict;
    [SerializeField]
    protected GrowthStats entityStatsGrowth;

    protected float startTimer;

    private float countForBirthday;

    protected bool dead;

    public event System.Action OnDeath;

    protected virtual void Awake()
    {
        entityStatsDict = new Dictionary<string, float>();
        startTimer = Random.Range(0.1f, 10) / 10;
        entityStatsDict.Add("age", entityStats.age);
        entityStatsDict.Add("maxHealth", entityStats.maxHealth);
        entityStatsDict.Add("health", entityStats.health);
        entityStatsDict.Add("healthRegen", entityStats.healthRegen);
        entityStatsDict.Add("sizeMod", entityStats.sizeMod);
        entityStatsDict.Add("randomMutationChance", entityStats.randomMutationChance);
    }

    // Use this for initialization
    protected virtual void Start () {
        StartCoroutine(SlowUpdate());
        dead = false;
}

    #region UPDATE
    protected virtual void Update()
    {

    }

    IEnumerator SlowUpdate()
    {
        yield return new WaitForSeconds(startTimer);
        while (true)
        {
            if (!dead)
            {
                SetStats();

            }yield return new WaitForSeconds(0.2f);
        }
    }
    #endregion

    #region FUNCTIONS

    void SetStats()
    {
        entityStats.health += entityStats.healthRegen;
        if (entityStats.health > entityStats.maxHealth)
        {
            entityStats.health = entityStats.maxHealth;
        }
        else if (entityStats.health < 0)
        {
            entityStats.health = 0;
        }
    }

    void CheckDeath()
    {
        if(entityStats.health <= 0 && !dead)
        {
            SetStats();
            StopCoroutine(SlowUpdate());
            dead = true;
            entityStats.health = 0;
            Death();
        }
    }

    virtual protected void Death()
    {
        if (OnDeath != null)
        {
            OnDeath();
        }
    }

    #endregion


    #region INTERFACE
    public void TakeDamage(float damage)
    {
        entityStats.health -= damage;
        CheckDeath();
    }

    public void GetEaten(Animal eatingEntity)
    {
        
    }

    public void Eat()
    {

    }
    #endregion
}

#region ENTITYSTATS
[System.Serializable]
public class EntityStats
{
    public float age = 1;
    public float maxHealth = 10;
    public float health;
    public float healthRegen = 0;
    public float sizeMod = 1;
    public float randomMutationChance = 0.5f;
}

/*[System.Serializable]
public class Stats
{
    public float age = 1;
    public float strenght = 1;
    public float intelect = 1;
    public float maxHealth = 10;
    public float health;
    public float healthRegen = 0;
    public float maxStamina = 100;
    public float staminaRegen = 0;
    public float stamina;
    public float moveMentspeed = 1;
    public float sizeMod = 1;
    public float maxHunger = 20;
    public float getHungry = 0;
    public float hunger = 0;
    public float randomMutationChance = 0.5f;
}*/

[System.Serializable]
public class GrowthStats
{
    public float healthGrowth = 1;
    public float strengthGrowth = 1;
    public float intelectGrowth = 1;
    public float staminaGrowth = 10;
    public float moveMentspeed = 1;
    public float sizeModGrowth = 0.1f;
    public float hungerDecline = 1;
}

#endregion
