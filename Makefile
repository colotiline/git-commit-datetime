test:
	cd src && \
	dotnet test \
	/p:CollectCoverage=true \
	/p:IncludeTestAssembly=true \
	/p:ExcludeByFile=\"**/*Tests.cs\" \
	/p:CoverletOutputFormat=lcov \
	/p:CoverletOutput=./lcov.info