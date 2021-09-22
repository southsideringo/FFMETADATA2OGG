# FFMETADATA2OGG

Simple C# program that converts ffmpeg Metadata chapter breaks to the OGG format for use with mkvmerge or whatever other muxer likes the format.

Extract chapter metadata with ffmpeg like so:

ffmpeg.exe -i "input_file" -f ffmetadata "output_file.txt"

This will work from the debug\bin folder "FFMETADATA2OGG.exe" from the command line or ".\FFMETADATA2OGG.exe" in Powershell. You would just enter the path of the folder containing ffmpeg exported chapter metadata text files (currently have to be "\<filename\>.chapters.txt" - sorry) and hit enter and it creates new files in the OGG format named "<old_filename>.ogg.txt". It was built targeting .NET 5.0 so there's that to consider...

You could easily enough edit the "Program.cs" file to match whatever naming scheme you use. 

Just open up "Program.cs" in a text editor, scroll down to line 17 where it says :

string[] fileArray = Directory.GetFiles(path, "*chapters.txt");

and then change the part in double quotes to "*.txt", or whatever you prefer...



Plan to make it better over time. :-)

