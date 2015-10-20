using UnityEngine;
using System;
using System.Diagnostics;

using Debug = UnityEngine.Debug;

public class Benchmark : MonoBehaviour
{
    public virtual void Setup() {}
    public virtual void Run() {}
    public virtual void Cleanup() {}

    public void Execute()
    {
        Setup();
        Run();
        Cleanup();

        Destroy(this.gameObject);
    }

    protected void Perform(string name, Action benchmark)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        benchmark.Invoke();

        sw.Stop();

        Debug.Log(string.Format("{0} : elapsed time = {1}ms", name, sw.ElapsedMilliseconds));
    }

    public static T Load<T>(string testName = "Benchmark") where T : MonoBehaviour
    {
        GameObject go = new GameObject(testName);
        T test = go.AddComponent<T>();

        return test;
    }
}
