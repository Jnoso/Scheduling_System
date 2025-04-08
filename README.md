C# application that uses a MySQL database to add, edit, or delete customer records and customer appointments.

The application has a user login that verifies the user login exists in MySQL and can determine the location the user is using the application from.

The application stores customer records such as name, address, phone number, city, and country.

Customer name, city, and country are in a different data table that are cascaded to add, edit, or delete the data from MySQL as needed.

Appointments data are also stored in MySQL database and can be edited or deleted by the user. Prevents scheduling of overlapping appointments and a calendar view feature to view appointments on a specific day.
