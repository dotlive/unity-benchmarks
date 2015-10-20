using UnityEngine;
using System.Collections;
using System;
using System.IO;

using Protobuf;

public class BenchmarkProtobuf : Benchmark
{
    public int N = 10000;

    public override void Run()
    {
        Perform("Protobuf serialization", RunSerialize);
    }

    void RunSerialize()
    {
        for (int i = 0; i < N; i++)
        {
            EmbeddedMessage embedded = EmbeddedMessage.CreateBuilder()
                                                      .SetId(i)
                                                      .BuildPartial();
            TestMessage message = TestMessage.CreateBuilder()
                                             .SetId(1)
                                             .SetText(@"Test message included")
                                             .SetEmbedded(embedded)
                                             .BuildPartial();

            using (MemoryStream ms = new MemoryStream())
            {
                message.WriteTo(ms);

                TestMessage parsed = TestMessage.ParseFrom(ms.ToArray());

                if (parsed.Embedded.Id != i) throw new Exception("Invalid embedded value");
            }
        }
    }
}
