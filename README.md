# About the project
This project is a web system developed using ASP.NET MVC, following a Clean Architecture approach with a structured separation into Infrastructure, Web, Domain, and Application layers. The system enables the management of rental properties, including property registration, associated rooms, and available amenities. <br><br>
The system follows the CRUD (Create, Read, Update, Delete) pattern, allowing users to perform essential operations for property management in an intuitive and efficient manner. Additionally, one of the key features of this project is the image upload functionality, enabling each property to have associated images for better presentation. <br><br>
This project emphasizes best practices in code organization, separation of concerns, and modularity, making it scalable and easy to maintain.

# Tech Stack
The project was developed using .NET, specifically ASP.NET MVC, following a structured approach for web applications. HTML and CSS were used to build the pages, with C# handling loops and dynamic rendering based on the selected item. Styling was enhanced with Bootstrap, ensuring a responsive design. For data persistence, Entity Framework, the native ASP.NET ORM, was used to map and manage database tables, storing the information in SQL Server.
<table align="center">
    <tr>
        <th></th>
        <th>
            Frontend
        </th>
        <th>
            Backend
        </th>
    </tr>
    <tr>
        <th>
            Languages
        </th>
        <td>
            <img alt="HTML5" src="https://img.shields.io/badge/html5-%23E34F26.svg?style=for-the-badge&logo=html5&logoColor=white"/>
            <img alt="CSS3" src="https://img.shields.io/badge/css3-%231572B6.svg?style=for-the-badge&logo=css3&logoColor=white"/>
        </td>
        <td>
            <img alt="C#" src="https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white" />
        </td>
    </tr>
    <tr>
        <th>
            Frameworks
        </th>
        <td>
          <img alt="Bootstrap" src="https://img.shields.io/badge/bootstrap-%238511FA.svg?style=for-the-badge&logo=bootstrap&logoColor=white" />
        </td>
        <td>
            <img alt="dotNet" src="https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white"/>
        </td>
    </tr>
    <tr>
        <th>
            IDE / Editor
        </th>
        <td></td>
        <td>
            <img alt="Visual Studio" src="https://img.shields.io/badge/Visual%20Studio-5C2D91.svg?style=for-the-badge&logo=visual-studio&logoColor=white"/>
        </td>
    </tr>
    <tr>
          <th>
              Tool
          </th>
          <td></td>
          <td>
              <img alt="SQL Server" src="https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white"/>
          </td>
      </tr>
</table>

# Requirements
1. Install [`.NET SDK`](https://dotnet.microsoft.com/en-us/download) (includes .NET Runtime).
2. Install [`SQL Server Express`](https://www.microsoft.com/en-us/sql-server/sql-server-downloads).
3. Install an IDE of your choice. I personally recommend [`Visual Studio`](https://visualstudio.microsoft.com/downloads/) [OPTIONAL].

# How to run locally (command line)
1. Run a `git clone` of the repository:
```
git clone https://github.com/LucasOkokama/home-book-app-aspnetmvc.git
```
2. Open the `home-book-app-aspnetmvc` folder and Install the `dependencies`:
```
cd home-book-app-aspnetmvc
dotnet restore
```
3. It may be necessary to update the connection string in the `appsettings.json`. Make sure to replace `NBLUCAS` with YOUR appropriate server name. If you're not using Windows Authentication (`Trusted_Connection=True`), ensure you add your `User Id` and `Password` for SQL Server Authentication.
```
"ConnectionStrings": {
  "DefaultConnection": "Server=NBLUCAS\\SQLEXPRESS;Database=HomeBookApp;Trusted_Connection=True;TrustServerCertificate=true"
}
```
4. Open the `HomeBookApp.Infrastructure` folder and `Run the migrations`:
```
cd ../homebookapp.infrastructure
dotnet ef database update --startup-project /path/to/homebookapp.web
```
5. Open the `HomeBookApp` folder and `Run the project`:
```
cd ../homebookapp
dotnet run
```
6. Access `localhost` to open the website:
```
https://localhost:7097
```

# References
The development of this project was guided by the video [`Clean Architecture Fundaments in .NET Core MVC (.NET 8)`](https://www.youtube.com/watch?v=CAwpmoA7sno), produced by [`Bhrugen Patel`](https://github.com/bhrugen)

# License
```
MIT License

Copyright (c) 2025 Lucas Kazuhiro Okokama

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```
