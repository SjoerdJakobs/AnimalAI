using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScriptAndPointsHandler : MonoBehaviour {

    IBehave[] getIBehaveScripts;
    IBehave currentScript;

    Dictionary<int,IBehave> iBehaveScripts;
    Dictionary<int, float> valuesDict;

    int runningScript;
	// Use this for initialization
	void Awake () {

        iBehaveScripts = new Dictionary<int, IBehave>();

        valuesDict = new Dictionary<int, float>();
        valuesDict.Add(1, 1);

        getIBehaveScripts = GetComponents<IBehave>();

        foreach(IBehave i in getIBehaveScripts)
        {
            iBehaveScripts.Add(i.ReturnScriptNr(),i);
            //print(i);
            //print(i.ReturnScriptNr());
        }

        currentScript = iBehaveScripts[0];
        //print(currentScript);
        StartCoroutine(ManageValues());
    }

    public void inputValue(int scriptNr, float value)
    {
        //valuesDict[scriptNr] = valuefl;
        if (!valuesDict.ContainsKey(scriptNr))
        {
            valuesDict.Add(scriptNr, value);
            //print("ok");
        }
        else
        {
            valuesDict[scriptNr] = value;
            //print("update plis");
        }
    }

    IEnumerator ManageValues()
    {
        while(true)
        {
            int highestKey = 0; ;
            float highestValue = 0;
            foreach (KeyValuePair<int, float> entry in valuesDict)
            {
                if(entry.Value >= highestValue)
                {
                    highestValue = entry.Value;
                    highestKey = entry.Key; 
                }
                // do something with entry.Value or entry.Key
            }

            if (iBehaveScripts[highestKey] != currentScript)
            {
                currentScript.StopScript();

                currentScript = iBehaveScripts[highestKey];

                currentScript.StartScript();
            }

            yield return new WaitForSeconds(0.1f);
        }
    }
}
