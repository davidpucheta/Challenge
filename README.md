# Challenge
Products and categories webapi challenge

Docker instructions
- Run docker-compose build
- Run docker-compose up
- Go to http://localhost:8000/swagger/index.html
- Use Swagger (or other rest client like postman) to upload the csv file using the import file endpoint and import its data to the Database.
- Use  Swagger or rest client to query the database, filtering, search and paging is supported.

Non docker instructions 
- Update PostGres connection string in appsetting.json
- Build app
- Run Update-Database to apply migrations
- Run app, browser will open swagger
- Use Swagger (or other rest client like postman) to upload the csv file using the import file endpoint and import its data to the Database.
- Use  Swagger or rest client to query the database, filtering, search and paging is supported.

davidpucheta@gmail.com
