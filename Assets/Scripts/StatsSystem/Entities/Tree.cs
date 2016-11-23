using UnityEngine;
using System.Collections;

public class Tree : Plant {

    [SerializeField]
    private GameObject stump;

    override protected void Death()
    {
        base.Death();
        Instantiate(stump, transform.position, Quaternion.identity);
        DestroyObject(gameObject);
    }
}
