using UnityEngine;
using System.Collections;

public class EntityType1 : LivingEntity {

	// Use this for initialization
	override protected void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	override protected void Update () {
        base.Update();
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
