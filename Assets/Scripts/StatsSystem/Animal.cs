using UnityEngine;
using System.Collections;

public class Animal : LivingEntity
{

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

            yield return new WaitForSeconds(0.1f);
        }
    }
}
[System.Serializable]
public class AnimalStats : Stats
{
    public float strenght = 1;
    public float intelect = 1;
    public float maxStamina = 100;
    public float staminaRegen = 0;
    public float stamina;
    public float moveMentspeed = 1;
}