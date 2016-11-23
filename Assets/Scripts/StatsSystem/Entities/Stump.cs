using UnityEngine;
using System.Collections;

public class Stump : MonoBehaviour
{

    [SerializeField]
    private GameObject tree;

    // Use this for initialization
    void Start()
    {
        Invoke("SpawnTree", Random.Range(30, 180));
    }

    void SpawnTree()
    {
        Instantiate(tree, transform.position,Quaternion.identity);
    }
}
