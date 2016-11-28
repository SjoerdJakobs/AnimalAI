using UnityEngine;
using System.Collections;
using System.Threading;
//using System.Diagnostics;

public class Threading : MonoBehaviour
{
    int number1 = 1;
    int number2 = 2;
    int number3 = 2;
    Thread a;
    Thread b;


    readonly object locker = new object();

    void Start()
    {
        
        a = new Thread(thread1);
        b = new Thread(thread2);

        StartCoroutine(threadRunner());
    }
    IEnumerator threadRunner()
    {
        while(true)
        {
            a.Start();
            b.Start();
            yield return new WaitForEndOfFrame();
        }
    }

    void thread1()
    {
        lock (locker)
        {
            Debug.Log(number1 * number2);
            number2++;
            /*for (int i = 0; i < 10; i++)
            {
                System.Diagnostics.Debug.WriteLine("log me");
                UnityEngine.Debug.Log("log me 2");
            }*/
            a.Abort();
        }
    }
    void thread2()
    {
        lock (locker)
        {
            Debug.Log(number2 * number3);
            number1++;
            b.Abort();
        }
    }
}