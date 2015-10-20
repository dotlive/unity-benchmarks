all: protobuf flatbuf

protobuf: clean-protobuf
	protoc --csharp_out=benchmarks/Assets/Scripts/Protocol/Protobuf protocol/*.proto

clean-protobuf:
	rm -rf benchmarks/Assets/Scripts/Protocol/Protobuf/*.cs
	rm -rf benchmarks/Assets/Scripts/Protocol/Protobuf/*.meta

flatbuf: clean-flatbuf
	flatc -n -o benchmarks/Assets/Scripts/Protocol/Flatbuffers protocol/*.fbs

clean-flatbuf:
	rm -rf benchmarks/Assets/Scripts/Protocol/Flatbuffers/*.cs
	rm -rf benchmarks/Assets/Scripts/Protocol/Flatbuffers/*.meta
