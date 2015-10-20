// automatically generated, do not modify

namespace FlatBuffers
{

using FlatBuffers;

public class TestMessage : Table {
  public static TestMessage GetRootAsTestMessage(ByteBuffer _bb) { return GetRootAsTestMessage(_bb, new TestMessage()); }
  public static TestMessage GetRootAsTestMessage(ByteBuffer _bb, TestMessage obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public static bool TestMessageBufferHasIdentifier(ByteBuffer _bb) { return __has_identifier(_bb, "TEST"); }
  public TestMessage __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public int Id() { int o = __offset(4); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; }
  public EmbeddedMessage Embedded() { return Embedded(new EmbeddedMessage()); }
  public EmbeddedMessage Embedded(EmbeddedMessage obj) { int o = __offset(6); return o != 0 ? obj.__init(__indirect(o + bb_pos), bb) : null; }
  public string Text() { int o = __offset(8); return o != 0 ? __string(o + bb_pos) : null; }

  public static int CreateTestMessage(FlatBufferBuilder builder,
      int id = 0,
      int embedded = 0,
      int text = 0) {
    builder.StartObject(3);
    TestMessage.AddText(builder, text);
    TestMessage.AddEmbedded(builder, embedded);
    TestMessage.AddId(builder, id);
    return TestMessage.EndTestMessage(builder);
  }

  public static void StartTestMessage(FlatBufferBuilder builder) { builder.StartObject(3); }
  public static void AddId(FlatBufferBuilder builder, int id) { builder.AddInt(0, id, 0); }
  public static void AddEmbedded(FlatBufferBuilder builder, int embeddedOffset) { builder.AddOffset(1, embeddedOffset, 0); }
  public static void AddText(FlatBufferBuilder builder, int textOffset) { builder.AddOffset(2, textOffset, 0); }
  public static int EndTestMessage(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return o;
  }
  public static void FinishTestMessageBuffer(FlatBufferBuilder builder, int offset) { builder.Finish(offset, "TEST"); }
};


}
