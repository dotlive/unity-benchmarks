// automatically generated, do not modify

namespace FlatBuffers
{

using FlatBuffers;

public class EmbeddedMessage : Table {
  public static EmbeddedMessage GetRootAsEmbeddedMessage(ByteBuffer _bb) { return GetRootAsEmbeddedMessage(_bb, new EmbeddedMessage()); }
  public static EmbeddedMessage GetRootAsEmbeddedMessage(ByteBuffer _bb, EmbeddedMessage obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public EmbeddedMessage __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public int Id() { int o = __offset(4); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; }

  public static int CreateEmbeddedMessage(FlatBufferBuilder builder,
      int id = 0) {
    builder.StartObject(1);
    EmbeddedMessage.AddId(builder, id);
    return EmbeddedMessage.EndEmbeddedMessage(builder);
  }

  public static void StartEmbeddedMessage(FlatBufferBuilder builder) { builder.StartObject(1); }
  public static void AddId(FlatBufferBuilder builder, int id) { builder.AddInt(0, id, 0); }
  public static int EndEmbeddedMessage(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return o;
  }
};


}
