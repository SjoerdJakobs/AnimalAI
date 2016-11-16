using UnityEngine;
using System.Collections;

public class RunScript : BehaveScript
{
    //this will run once when the script epened
    override protected void OpenBehaviour()
    {
        base.OpenBehaviour();
        print("Open" + scriptNR);
    }

    //this will run every 0.1 seconds
    override protected void Behaviour()
    {
        base.Behaviour();
        print("test"+ scriptNR);
    }

    //this will run once when this script is closed
    override protected void CloseBehaviour()
    {
        base.CloseBehaviour();
        //StopAllCoroutines();
        print("Close"+ scriptNR);
    }
}
