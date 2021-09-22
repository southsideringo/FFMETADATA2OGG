# FFMETADATA2OGG

Simple C# program that converts ffmpeg Metadata chapter breaks to the OGG format for use with mkvmerge or whatever other muxer likes the format.

This will work from the debug\bin folder "FFMETADATA2OGG.exe" from the command line or ".\FFMETADATA2OGG.exe" in Powershell. You would just enter the path of the folder containing ffmpeg exported chapter metadata text files (currently have to be "\<filename\>.chapters.txt" - sorry) and hit enter and it creates new files in the OGG format named "<old_filename>.ogg.txt". It was built targeting .NET 5.0 so there's that to consider...

Plan to make it better over time. :-)

