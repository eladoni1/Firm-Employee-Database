# Firm-Employee-Database
Backend - .NET 5, Frontend - Vue.js, /w MongoDB

Walkthrough on how to set up the DB :

1) Download MongoDB Compass [here](https://www.mongodb.com/products/compass).

2) Go to [MongoDB site](https://www.mongodb.com) and make a new empty cluster using MongoDB Atlas

3) In MongoDB Atlas, copy the connection link and connect with MongoDB Compass

4) Create new Database, then 2 new Collections - Employee and Department with the following variables :

Department - a) DepartmentId, b) DepartmentName

Employee - a) EmployeeId, b) EmployeeName, c) Department, d) DateOfJoining, e) PhotoFileName

Add few examples of each.


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
