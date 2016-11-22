using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScriptAndPointsHandler : MonoBehaviour {

    /// <summary>
    /// This script is the backbone of the utility ai.
    /// It gets all the behave scripts and gets their scriptNr and adds them to a dictionary.
    /// Sourcing another script it can give points to scriptNrs.
    /// example:
    /// ---------------------------------------------------------------
    /// public class SomeClass
    /// {
    ///     private ScriptAndPointsHandler scriptAndPointsHandler;
    ///     private float food
    ///     void Start()
    ///     {
    ///         food = 71;
    ///         scriptAndPointsHandler.inputValue(1, food);
    ///     }
    /// }
    /// ---------------------------------------------------------------
    /// This will give this script a dictionary value of 1 and 71.
    /// It compares the value against other values if there are any and pickes the highest value.
    /// Then it compares the key of the highest value to the keys of the dictionary wich are scriptNrs.
    /// In this case it gets the script with scriptNr 1.
    /// </summary>

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

            //print("key " + highestKey);
            //print("value " + highestValue);

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
