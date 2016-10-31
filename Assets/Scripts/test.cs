using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {


    [SerializeField]
    private LivingEntity enemy;

    // Use this for initialization
    void Start () {
        enemy = GetComponent<LivingEntity>();

        enemy.OnDeath += Tested;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Tested()
    {
        StartCoroutine(testCor());
    }

    IEnumerator testCor()
    {
        print("test1");

        yield return new WaitForSeconds(0.25f);

        print("test2");
    }

}
