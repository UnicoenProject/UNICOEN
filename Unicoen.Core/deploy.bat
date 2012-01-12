mkdir nuspec
copy *.nuspec nuspec /y
cd nuspec
mkdir lib
mkdir content
copy ..\bin\Release\*.dll lib\
copy ..\bin\Release\*.pdb lib\
del lib\Paraiba.*
del lib\Antlr3.*
del lib\Code2Xml.*
del *.nupkg
FOR %%f IN (*.nuspec) DO (
	nuget pack %%f
)
FOR %%f IN (*.nupkg) DO (
	nuget push %%f
)
