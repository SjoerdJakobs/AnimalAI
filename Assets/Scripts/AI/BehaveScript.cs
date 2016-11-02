using UnityEngine;
using System.Collections;

public class BehaveScript : MonoBehaviour, IBehave
{
    /// <summary>
    /// This script is the base to build any behaviour script used by the utility AI.
    /// It has a start, stop and update function and can be called with the interface IBehave.
    /// </summary>
    
    [SerializeField]
    protected int scriptNR;

    public int ReturnScriptNr()
    {
        return (scriptNR);
    }

    public void StartScript()
    {
        OpenBehaviour();
        StartCoroutine(ScriptUpdate());
    }

    public void StopScript()
    {
        StopCoroutine(ScriptUpdate());
        CloseBehaviour();
    }

    IEnumerator ScriptUpdate()
    {
        while(true)
        {
            Behaviour();

            yield return new WaitForSeconds(0.1f);
        }
    }

    protected virtual void OpenBehaviour()
    {

    }

    protected virtual void Behaviour()
    {

    }

    protected virtual void CloseBehaviour()
    {

    }
}
