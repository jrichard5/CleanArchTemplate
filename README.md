# Template_CleanArchAPI


TODO:
1. Fix connection string --- impossible (unless system env variable, or Azure Key Vault (or other cloud solutions), maybe just a simple read from file)
2. ~~make POST, PUT, DELETE controller~~
3. Middleware  Exception Handling
4. Unit Testing
5. Fluent Validation (somewhat will help against cross site scripting)
6. Look how to encode data to prevent crosssite scripting
7. Add Logging
8. Authenication 

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


