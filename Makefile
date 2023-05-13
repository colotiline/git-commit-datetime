test:
	cd src && \
	dotnet test \
	/p:CollectCoverage=true \
	/p:IncludeTestAssembly=true \
	/p:ExcludeByFile=\"**/*Tests.cs\" \
	/p:CoverletOutputFormat=lcov \
	/p:CoverletOutput=./lcov.info

pack:
	cd src/Colotiline.Git.DateTime.Tool && ETA=true dotnet pack -c Release

publish:
	cd ./nupkg && \
	dotnet nuget push *.nupkg -s https://api.nuget.org/v3/index.json  \
	-k ${secrets.NUGET_API_KEY} --skip-duplicate -n true