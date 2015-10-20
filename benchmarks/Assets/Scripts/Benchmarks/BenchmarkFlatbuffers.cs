using UnityEngine;
using System.Collections;
using System;
using System.IO;

using FlatBuffers;

public class BenchmarkFlatbuffers : Benchmark
{
    public int N = 1;

    public override void Run()
    {
        Perform("Flatbuffers serialization", () => Debug.LogWarning("Flatbuffer serialization is work in progress"));
    }

    void RunSerialize()
    {
        for (int i = 0; i < N; i++)
        {
            FlatBufferBuilder messageBuffer = new FlatBufferBuilder(100);

            var text = messageBuffer.CreateString(@"Test message included");

            int embeddedOffset = EmbeddedMessage.CreateEmbeddedMessage(messageBuffer, i);

            TestMessage.StartTestMessage(messageBuffer);
            TestMessage.AddText(messageBuffer, text.Value);
            TestMessage.AddEmbedded(messageBuffer, embeddedOffset);
            TestMessage.AddId(messageBuffer, i);
            int testMessage = TestMessage.EndTestMessage(messageBuffer);
            TestMessage.FinishTestMessageBuffer(messageBuffer, testMessage);

            string s = "";
            for (int j = 0; j < messageBuffer.DataBuffer.Data.Length; j++) s += messageBuffer.DataBuffer.Data[i].ToString() + ", ";
            Debug.Log(s);

            using (MemoryStream ms = new MemoryStream(messageBuffer.DataBuffer.Data,
                                                      0,
                                                      messageBuffer.DataBuffer.Data.Length))
            {
                ByteBuffer byteBuffer = new ByteBuffer(ms.ToArray());
                TestMessage parsed = TestMessage.GetRootAsTestMessage(byteBuffer);

                if (parsed.Embedded().Id() != i) throw new Exception("Invalid embedded value");
            }
        }
    }
}
