using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ScriptAndPointsHandler : MonoBehaviour {

    IBehave[] getIBehaveScripts;
    List<IBehave> iBehaveScripts;
	// Use this for initialization
	void Start () {

        getIBehaveScripts = GetComponents<IBehave>();

        foreach(IBehave i in getIBehaveScripts)
        {
            print(i);
            print(i.ReturnScriptNr());
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
