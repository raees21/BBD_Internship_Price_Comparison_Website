# Groce

## Grocery Price Comparison Website

### Project Target Audience

Our objective for this project was to make an easy to use web application.This application  would allow a user to search for a general food item and then compare this items prices from multiple shops. Once they have chosen the item from the shop they prefer, it would then put this item into a list that the user can edit and interact with.

### Requirements

1. HTML
2. CSS
3. JavaScript
4. C# .NET
5. Microsoft SQL Server
6. SQL Server Management Studio

### Application Setup Steps

1. Install Microsoft SQL Server and run a SQL Server
2. Install SSMS (SQL Server Management Studio) and connect to the Microsoft Server Instance
3. Run the SQLDatabaseV1.sql script within the Source Code to setup the entire Database with tables and mock values
4. Login using Google or other available services making use of the login system for the Grocery Website
5. START SHOPPING!!!!

### Architecture

This application makes use of the MVC Paradigm (Model View Controller)

UI ---> Controllers ---> Models ----> Data Repository ---> SQL Database

1. Controllers
 - Control the flow of data between the UI and the Backend Logic of the Application
2. Models
 - Models are used to translate the data from the database into identifiable objects so it can be used to proccess logic in the Backend of the Application
3. Views/UI
 - The actual HTML - CSS - Javascript code used to render the User Interface of the project which gets rendered from the controllers
4. Assets
 - Common icons, pictures and other images used to help render the interface
5. Launch Settings
 - Sets the initial launch configuration for the Application
6. Startup Class
 - Startsup initial services so the application can run - such as Auth0 for Google authentication and the Database

### Testing

These are the tests I executed to test the Application

a) Preliminary Checks, See if I have a Web Browser Installed
b) Start Webserver and SQL Server
c) Login Using Google
d) Type a Grocery Name in text box and press enter
e) Add required Items to cart and see if cart populates
f) Logout of user
g) Log back in

Expected Outcomes

a) All Preliminary checks done and Web Browser was installed <br/>
b) Webserver Starts and connects to Database <br/>
c) Login Successfull and user is now logged into website <br/>
d) List of stores with the selected grocery appears and Highlights the cheapest option <br/>
e) Cart Populates correctly <br/>
f) User Logged out successfully <br/>
g) User Logged in and cart is kept in memory so it shows the same as before <br/>







