.PHONY: console
console:
	dotnet run --project ConsoleApp

.PHONY: graphic
graphic:
	dotnet run --project Grafica
.PHONY: blazor
blazor:
	dotnet watch run --project Domino
