# Firm-Employee-Database
Backend - .NET 5, Frontend - Vue.js, /w MongoDB

Walkthrough on how to set up the DB :

1) Download MongoDB Compass [here](https://www.mongodb.com/products/compass).
![Download Mongo Compass](https://raw.githubusercontent.com/eladoni1/Firm-Employee-Database/main/ReadMePhotos/1.png)

2) Go to [MongoDB site](https://www.mongodb.com) and make a new empty cluster using MongoDB Atlas.


![Create Account](https://raw.githubusercontent.com/eladoni1/Firm-Employee-Database/main/ReadMePhotos/2.png)



![Create new cluster](https://raw.githubusercontent.com/eladoni1/Firm-Employee-Database/main/ReadMePhotos/3.png)

3) In MongoDB Atlas, copy the connection link, and edit it (change '<password>' field) and connect with MongoDB Compass.


![Connection link 1](https://raw.githubusercontent.com/eladoni1/Firm-Employee-Database/main/ReadMePhotos/4.png)



![Connection link 2](https://raw.githubusercontent.com/eladoni1/Firm-Employee-Database/main/ReadMePhotos/5.png)

Note: You might need to add your IP Address in Network Access under Security tab.

4) After creating a new Database, then 2 new Collections - Employee and Department with the following variables :

Department - a) DepartmentId, b) DepartmentName

Employee - a) EmployeeId, b) EmployeeName, c) Department, d) DateOfJoining, e) PhotoFileName

Add few examples of each.



![Adding new Collection](https://raw.githubusercontent.com/eladoni1/Firm-Employee-Database/main/ReadMePhotos/6.png)




We have implemented the following functions -
Department:
  a) Get - returns all departments.
  b) Post - add a new department.
  c) Put - edit a department's variables (DepartmentName).
  d) Delete - deletes a department.
  
Employee:
  a) Get - returns all employees.
  b) Post - add a new employee.
  c) Put - edit an employee's variables (EmployeeName, Department, DateOfJoining, PhotoFileName).
  d) Delete - deletes an employee.
