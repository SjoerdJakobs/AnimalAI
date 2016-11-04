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

        getIBehaveScripts = GetComponents<IBehave>();

        foreach(IBehave i in getIBehaveScripts)
        {
            iBehaveScripts.Add(i.ReturnScriptNr(),i);
            //print(i);
            //print(i.ReturnScriptNr());
        }

        currentScript = iBehaveScripts[3];
        //print(currentScript);
    }

    public void inputValue(int scriptNr, float valuefl)
    {
        valuesDict[scriptNr] = valuefl;
        if (valuesDict[scriptNr] != null)
        {
            valuesDict.Add(scriptNr, valuefl);
            print("ok");
        }
        else
        {
            valuesDict[scriptNr] = valuefl;
        }
    }

    IEnumerator ManageValues()
    {
        while(true)
        {
            //compare values
            //int highest= highest value key
            //highestScript = iBehaveScripts[highest value key];
            //KeyValuePair<int, float> kvp = values;


            /*if (iBehaveScripts[highest value key] != currentScript)
            {
                currentScript.StopScript();

                currentScript = iBehaveScripts[highest value key];

                currentScript.StartScript();
            }*/

            //runningScript = currentScript key ;

            yield return new WaitForSeconds(0.1f);
        }
    }
}
