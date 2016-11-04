using UnityEngine;
using System.Collections;

public class GoToShelter : BehaveScript
{
    //this will run once when the script epened
    override protected void OpenBehaviour()
    {
        base.OpenBehaviour();
        print("Open");
    }

    //this will run every 0.1 seconds
    override protected void Behaviour()
    {
        base.Behaviour();
        print("test");
    }

    //this will run once when this script is closed
    override protected void CloseBehaviour()
    {
        base.CloseBehaviour();
        print("Close");
    }
}
