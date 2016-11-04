using UnityEngine;
using System.Collections;

public class EntityType1 : LivingEntity
{
    [SerializeField]
    private EntityBehaviour entityBehaviour;

    private ScriptAndPointsHandler scriptAndPointsHandler;

    // Use this for initialization
    override protected void Start()
    {
        base.Start();
        scriptAndPointsHandler = GetComponent<ScriptAndPointsHandler>();
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

            scriptAndPointsHandler.inputValue(1, 132.3f);

            yield return new WaitForSeconds(0.1f);
        }
    }
}
#region ENTITYBEHAVIOUR

[System.Serializable]
public class EntityBehaviour
{
    public float aggresion = 1;
    public float carOmniHerbi = 0;
    public float brave = 1;
    public float lazyness = 1; 
}

#endregion
