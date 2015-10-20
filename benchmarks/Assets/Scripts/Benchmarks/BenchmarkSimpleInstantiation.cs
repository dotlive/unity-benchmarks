using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Diagnostics;

using Debug = UnityEngine.Debug;

public class BenchmarkSimpleInstantiation : Benchmark
{
    public int N = 5000;
    private readonly string prefabPath = @"Tests/Benchmarks/SimpleInstantiation";

    private GameObject rootObject = null;

    public override void Setup()
    {
        rootObject = new GameObject("BenchmarkRoot");
    }

    public override void Run()
    {
        Perform("AddComponent", RunAddComponent);
        Perform("Instantiate", RunInstantiate);
        Perform("Instantiate (cached)", RunInstantiateCached);
    }

    public override void Cleanup()
    {
        Destroy(rootObject);
    }

    private void RunAddComponent()
    {
        for (int i = 0; i < N; i++)
        {
            GameObject go = new GameObject("Test");
            go.AddComponent<DummyComponent>();

            go.transform.SetParent(rootObject.transform);
        }
    }

    private void RunInstantiate()
    {
        for (int i = 0; i < N; i++)
        {
            GameObject go = GameObject.Instantiate(Resources.Load(prefabPath)) as GameObject;
            go.transform.SetParent(rootObject.transform);
        }
    }

    private void RunInstantiateCached()
    {
        GameObject cachedPrefab = Resources.Load(prefabPath) as GameObject;
        for (int i = 0; i < N; i++)
        {
            GameObject go = GameObject.Instantiate(cachedPrefab) as GameObject;
            go.transform.SetParent(rootObject.transform);
        }
    }
}
