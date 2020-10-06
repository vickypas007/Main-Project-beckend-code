# QuickPick-Web-Api
This app is developed for those users who want to order their goods or items from the local shop in the locality.

#06/10/2020
RUN USING CMD

1.create a Directory Like QuickPick.

2. open CMD on that directiry location.

3. write command
git clone --branch VIckyBranch https://github.com/vickypas007/QuickPick-Web-Api.git
cd QuickPick-Web-Api
git checkout VIckyBranch
dotnet restore
cd QuickPick Web Api
dotnet run 

3. then after a crome will open and then change the url to https://localhost:5001/WeatherForecast or https://localhost:5001/api/Customer

4. After successfully run,  open POSTMEN , give a post method and paste the url like https://localhost:5001/api/Customer/signup

5. in postman select Body , then select row and change Type to JSON

6. then paste the content in body(row)
{
    "Password":"12345",
    "EmailId":"assj@gmail.com",
    "FirstName":"Rajeev",
    "MiddleName":"Kumar",
    "LastName":"Paswan",
    "Gender":"Male",
    "ContactNo":"8092460475",
    "Address1":"Address1",
    "Address2": "Address2",
    "Address3":"Address3",
    "City":"Bokaro",
    "State":"Jharkhand",
    "Country":"India",
    "PinCode":829127
}

7.  And Then Check the responce. Also open your mysql workbench and then check.

//----------------------------------------------------------------------------------------------------------------------


#29-09-2020
I created a customer controller for registration 
----------------Steps for run------------------
1. change the connection string in appsetting.development.json
"DefaultConnection": "Server=127.0.0.1;Database=quickpick;Uid=root;Pwd=root;"
2. for updating Database
   1. go to tools in vs select the  nuGet packege manager and select Package manager console
   2. Set QuickPickWebApi.Core as a Default project in package manager console
   3. and write " Update-Database " command , then all table is created in localdb
3. then click on run the project in vs
4. a web browser will open and then change the URL https://localhost:44369/api/Customer/signup
