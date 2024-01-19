# SystemForSharingInfoInHospitals

The project was generated using the [Clean.Architecture.Solution.Template](https://github.com/jasontaylordev/SystemForSharingInfoInHospitals) version 8.0.0.

## PV293 Info
This project is related to this topic in IS: https://is.muni.cz/auth/rozpis/tema?fakulta=1433;kod=PV293;predmet=1568719;sorter=vedouci;balik=502485;tema=502511;uplne_info=1;obdobi=9223

Students who collaborate on this topic:
 - [Jaroslav Plšek](https://is.muni.cz/auth/osoba/524640) 524640
 - [Jan Straka](https://is.muni.cz/auth/osoba/514615) 514615

 ### Task 1
 There is a link to to figma: https://www.figma.com/file/dYQz3lVF8ujAZqDNmikVPS/Event-Storming-(Community)-(Copy)?type=design&node-id=1%3A21&mode=design&t=dn0KZw6tJQ2EbbVG-1

 ### Task 2

## Build

Run `dotnet build -tl` to build the solution.

## Run

To run the web application:

```bash
cd .\src\Web\
dotnet watch run
```

Navigate to https://localhost:5001. The application will automatically reload if you change any of the source files.

## Code Styles & Formatting

The template includes [EditorConfig](https://editorconfig.org/) support to help maintain consistent coding styles for multiple developers working on the same project across various editors and IDEs. The **.editorconfig** file defines the coding styles applicable to this solution.

## Code Scaffolding

The template includes support to scaffold new commands and queries.

Start in the `.\src\Application\` folder.

Create a new command:

```
dotnet new ca-usecase --name CreateTodoList --feature-name TodoLists --usecase-type command --return-type int
```

Create a new query:

```
dotnet new ca-usecase -n GetTodos -fn TodoLists -ut query -rt TodosVm
```

If you encounter the error *"No templates or subcommands found matching: 'ca-usecase'."*, install the template and try again:

```bash
dotnet new install Clean.Architecture.Solution.Template::8.0.0
```

## Test

The solution contains unit, integration, and functional tests.

To run the tests:
```bash
dotnet test
```

## Help
To learn more about the template go to the [project website](https://github.com/JasonTaylorDev/SystemForSharingInfoInHospitals). Here you can find additional guidance, request new features, report a bug, and discuss the template with other users.