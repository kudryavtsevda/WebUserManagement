# Sample CRUD ASP NET MVC 5 + RazorPages + ReactJS

### Solution structure
* Database project contains database scheme and seed script.
* Api is backend project based on dapper ORM.
* There are two UI projects: MVC.UI and UI.ReactJS
* XUnitTests contains integration tests only so far.

### Configuration
#### Api
Web.config contains DbConnection string. Don't forget to setup it properly.
#### MVC.UI
Web.config contains ServiceUrl app setting. Don't forget to setup it properly.
#### UI.ReactJS
* Web.config contains ServiceUrl app setting. Don't forget to setup it properly.
* Apply "npm install" for package.json file to download all dependencies.
