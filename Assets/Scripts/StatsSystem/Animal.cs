using UnityEngine;
using System.Collections;

public class Animal : LivingEntity
{
    [SerializeField]
    protected AnimalStats animalStats;
    override protected void Awake()
    {
        base.Awake();
        entityStatsDict.Add("strenght", animalStats.strenght);
        entityStatsDict.Add("intelect", animalStats.intelect);
        entityStatsDict.Add("maxStamina", animalStats.maxStamina);
        entityStatsDict.Add("staminaRegen", animalStats.staminaRegen);
        entityStatsDict.Add("stamina", animalStats.stamina);
        entityStatsDict.Add("maxHunger", animalStats.maxHunger);
        entityStatsDict.Add("getHungry", animalStats.getHungry);
        entityStatsDict.Add("hunger", animalStats.hunger);
        entityStatsDict.Add("moveMentspeed", animalStats.moveMentspeed);
    }

    override protected void Start()
    {
        base.Start();
        //print("halp");
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
            animalStats.stamina += animalStats.staminaRegen;
            if (animalStats.stamina > animalStats.maxStamina)
            {
                animalStats.stamina = animalStats.maxStamina;
            }
            else if (animalStats.stamina <= 0)
            {
                animalStats.stamina = 0.1f;
            }

            animalStats.hunger += animalStats.getHungry;
            if (animalStats.hunger > animalStats.maxHunger)
            {
                animalStats.hunger = animalStats.maxHunger;
            }
            else if (animalStats.hunger <= 0)
            {
                animalStats.hunger = 0.1f;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
[System.Serializable]
public class AnimalStats
{
    public float strenght = 1;
    public float intelect = 1;
    public float maxStamina = 100;
    public float staminaRegen = 0;
    public float stamina;
    public float maxHunger = 20;
    public float getHungry = 0;
    public float hunger = 0;
    public float moveMentspeed = 1;
}