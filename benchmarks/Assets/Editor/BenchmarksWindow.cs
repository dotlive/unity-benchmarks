using UnityEngine;
using UnityEditor;
using System;

public class BenchmarksWindow : EditorWindow
{
    [MenuItem("Window/Benchmarks")]
    static void AvatarViewer()
    {
        EditorWindow.GetWindow(typeof(BenchmarksWindow));
    }

    void OnGUI()
    {
        if (!EditorApplication.isPlaying)
        {
            EditorGUILayout.HelpBox(@"Please enter play mode to run benchmarks", MessageType.Warning);
            return;
        }

        if (GUILayout.Button("Instantiation"))
        {
            Benchmark.Load<BenchmarkInstantiation>().Execute();
        }

        if (GUILayout.Button("Simple Instantiation"))
        {
            Benchmark.Load<BenchmarkSimpleInstantiation>().Execute();
        }

        if (GUILayout.Button("Protobuf serialization"))
        {
            Benchmark.Load<BenchmarkProtobuf>().Execute();
        }

        if (GUILayout.Button("Flatbuffers serialization"))
        {
            Benchmark.Load<BenchmarkFlatbuffers>().Execute();
        }
    }
}
