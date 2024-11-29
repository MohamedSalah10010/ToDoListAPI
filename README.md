
# ToDoListAPI

ToDoListAPI is a simple and efficient RESTful API built using ASP.NET Core. This project allows users to manage tasks effectively with basic CRUD operations. Whether you're building your own task management application or learning API development, this project will help you understand how to handle tasks in a clean, organized way using modern development practices.

## Features

- **Create** tasks: Add new tasks with details like title, description, due date, and priority.
- **Read** tasks: Retrieve a list of all tasks or fetch a specific task by its ID.
- **Update** tasks: Modify the details of an existing task, such as status, due date, and priority.
- **Delete** tasks: Remove tasks from the database by their ID.
- **Validations**: Ensure that task data is correctly formatted and adheres to business rules before being saved.

## Technologies Used

- **ASP.NET Core**: A modern framework for building web APIs.
- **Entity Framework Core**: ORM for database interaction.
- **SQL Server**: Database for storing task data.

## API Endpoints

### `GET /api/tasks`
Fetches a list of all tasks.

**Response**:
```json
[
    {
        "id": 1,
        "title": "Task 1",
        "description": "Description of Task 1",
        "status": false,
        "dueDate": "2024-12-25",
        "priority": "High"
    },
    ...
]
```

### `GET /api/tasks/{id}`
Fetches a specific task by its ID.

**Response**:
```json
{
    "id": 1,
    "title": "Task 1",
    "description": "Description of Task 1",
    "status": false,
    "dueDate": "2024-12-25",
    "priority": "High"
}
```

### `POST /api/tasks`
Creates a new task.

**Request Body**:
```json
{
    "title": "New Task",
    "description": "Description of new task",
    "dueDate": "2024-12-31",
    "priority": "Medium"
}
```

**Response**:
```json
{
    "message": "Task created successfully"
}
```

### `PUT /api/tasks`
Updates an existing task.

**Request Body**:
```json
{
    "id": 1,
    "title": "Updated Task",
    "description": "Updated description",
    "status": true,
    "dueDate": "2024-12-31",
    "priority": "Low"
}
```

**Response**:
```json
{
    "message": "Task updated successfully"
}
```

### `DELETE /api/tasks/{id}`
Deletes a task by its ID.

**Response**:
```json
{
    "message": "Task deleted successfully"
}
```


## Database Configuration

This project uses a SQL Server database to store task data. The database connection string can be configured in the `appsettings.json` file.

