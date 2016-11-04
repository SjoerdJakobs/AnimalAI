using UnityEngine;
using System.Collections;

public class LivingEntity : MonoBehaviour , IAmLiving
{
    [SerializeField]
    protected Stats entityStats;
    [SerializeField]
    protected GrowthStats entityStatsGrowth;

    private float countForBirthday;

    protected bool dead;

    public event System.Action OnDeath;


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
        while (true)
        {
            if (!dead)
            {
                SetStats();

            }yield return new WaitForSeconds(0.25f);
        }
    }
    #endregion

    #region FUNCTIONS

    void SetStats()
    {
        if (entityStats.stamina < entityStats.maxStamina)
        {
            entityStats.stamina += entityStats.staminaRegen;
        }
        if (entityStats.health < entityStats.maxHealth)
        {
            entityStats.health += entityStats.maxHealth;
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
    }
    #endregion
}

#region ENTITYSTATS

[System.Serializable]
public class Stats
{
    public float age = 1;
    public float strenght = 1;
    public float intelect = 1;
    public float maxHealth = 10;
    public float health;
    public float healthRegen = 0.1f;
    public float maxStamina = 1;
    public float stamina;
    public float staminaRegen = 0.1f;
    public float moveMentspeed = 1;
    public float sizeMod = 1;
    public float hunger = 10;
    public float randomMutationChance = 0.5f;
}

[System.Serializable]
public class GrowthStats
{
    public float healthGrowth = 1;
    public float strengthGrowth = 1;
    public float intelectGrowth = 1;
    public float staminaGrowth = 1;
    public float moveMentspeed = 1;
    public float sizeModGrowth = 0.1f;
    public float hungerDecline = 1;
}

#endregion
