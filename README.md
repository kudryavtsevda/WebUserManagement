# Sample CRUD ASP NET MVC 5 + RazorPages + ReactJS

### Solution structure
* Database project contains database scheme and seed script.
* Api is backend project based on dapper ORM.
* There are two UI projects: MVC.UI and UI.ReactJS
* XUnitTests contains integration tests only so far.
![image](https://user-images.githubusercontent.com/4447809/112223312-29fbd700-8c43-11eb-91f0-341eb01ff298.png)


### Configuration
#### Api
Web.config contains DbConnection string. Don't forget to setup it properly.
#### MVC.UI
Web.config contains ServiceUrl app setting. Don't forget to setup it properly.
![image](https://user-images.githubusercontent.com/4447809/112223259-1a7c8e00-8c43-11eb-99a5-262152605dc1.png)

#### UI.ReactJS
* Web.config contains ServiceUrl app setting. Don't forget to setup it properly.
* Apply "npm install" for package.json file to download all dependencies.

![image](https://user-images.githubusercontent.com/4447809/112223159-fa4ccf00-8c42-11eb-8e84-6495654d1cff.png)
