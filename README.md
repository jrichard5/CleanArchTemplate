# Template_CleanArchAPI

To update database:

cd src
dotnet ef migrations add --startup-project .\ASPNETCoreWebApiTemplate --project .\InfrastructureLayer customNameOfMigration
dotnet ef database update --startup-project .\ASPNETCoreWebApiTemplate --project .\InfrastructureLayer


TODO:
1. Fix connection string --- impossible (unless system env variable, or Azure Key Vault (or other cloud solutions), maybe just a simple read from file)
2. ~~make POST, PUT, DELETE controller~~
3. ~~Middleware  Exception Handling~~
4. ~~Unit Testing~~
5. ~~Fluent Validation (somewhat will help against cross site scripting)~~
* ~~Fluent Validator unit test~~
6. ~~Look how to encode data to prevent crosssite scripting~~
*May need to use the AntiXSS library or HTMLSanitizer.  https://stackoverflow.com/questions/12618432/stopping-xss-when-using-webapi
* Oh yea, can also have SJ code in the URL query, and if the webpage displays that query back to user, the JS will run.  (Example:  you search book, somewhere on the webpage it says book, but instead of book, now it is JS)
7. ~~Add Logging~~
8. ~~Add rules to databse (like CatName can only be 64 chars long)~~
9. create/Read CSV files


Extra TODOs:
1. A more complicated LINQ query (i think thats two querys....but it looks better this way....)
2. Fluent validation with a collection
4. Add Content Security Policy / Use HTMLSanitizer
5. Authenication 


Extra info
* SQLServerStuff.txt
* ResearchLinks.txt


Other Apps - Why is it here? idk
1. make ERD for general notecard app  (make sure it can be fitted for japanese learning notecards)
2. Make console app that parses website to fill database  (SQLite)
3. Research desktop app architecture
4. Create desktop notecard app
5. make it a package for Linux
6. Host the webapi on Azure? or AWS? research this
7. make a docker file for the database?


Using https://www.c-sharpcorner.com/article/introduction-to-clean-architecture-and-implementation-with-asp-net-core/
* seems to be related to https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures
* another one https://www.c-sharpcorner.com/article/implementing-clean-architecture-on-net/
* used something a bit different than what I did at internship, but I guess good to learn something new

1st - Make Entity
* Forgot how to name id part (https://www.entityframeworktutorial.net/code-first/what-is-code-first.aspx)
*Grade+Id = GradeId

Dependency Injection -- https://www.c-sharpcorner.com/article/implementing-clean-architecture-on-net/


