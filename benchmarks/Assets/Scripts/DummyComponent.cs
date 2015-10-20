using UnityEngine;
using System.Collections;

public class DummyComponent : MonoBehaviour
{
    public string TestString = @"Test String";
    public int TestInt = 1;

    void Awake()
    {
        //bool flag = false;
        //for (int i = 0; i < 10000; i++) { flag = !flag; }
        StartCoroutine(Routine());
    }

    IEnumerator Routine()
    {
        yield return new WaitForSeconds(0.5f);
    }
}
