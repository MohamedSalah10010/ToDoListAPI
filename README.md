
# ToDoListAPI

This API allows you to manage tasks efficiently, providing endpoints to create, read, update, delete, and filter tasks. It includes features for task management, task status updates, and filtering tasks based on status, due date, and priority.

## Features

- **Task Management**: Create, update, delete, and fetch tasks.
- **Task Status Updates**: Mark tasks as complete or incomplete.
- **Task Filtering**: Filter tasks based on status, due date, or priority.
- **AutoMapper Integration**: DTOs used to handle task data transfer.

## Endpoints

### Task Management

- **GET /api/tasks**  
  Fetches all tasks.  
  Status = false => incomplete, Status = true => complete.  
  Priority levels:  
  - 0 => LOW  
  - 1 => MED  
  - 2 => HIGH  

  **Responses**:  
  - 200 OK: Successfully retrieved tasks.  
  - 404 Not Found: No tasks found.

- **GET /api/tasks/{id}**  
  Fetches a specific task by its ID.  
  Status = false => incomplete, Status = true => complete.  
  Priority levels:  
  - 0 => LOW  
  - 1 => MED  
  - 2 => HIGH  

  **Responses**:  
  - 200 OK: Successfully retrieved the task.  
  - 404 Not Found: Task not found.

- **POST /api/tasks**  
  Creates a new task.  
  **Request Body**:  
  ```json
  {
    "Title": "Task Title",
    "Description": "Task Description",
    "DueDate": "yyyy-mm-dd",
    "Priority": 0 (LOW) | 1 (MED) | 2 (HIGH)
  }
  ```
  **Responses**:  
  - 200 OK: Task created successfully.  
  - 400 Bad Request: Invalid task data.

- **PUT /api/tasks**  
  Updates an existing task.  
  **Request Body**:  
  ```json
  {
    "Id": 1,
    "Title": "Updated Task Title",
    "Description": "Updated Task Description",
    "Status": true | false,
    "DueDate": "yyyy-mm-dd",
    "Priority": 0 (LOW) | 1 (MED) | 2 (HIGH)
  }
  ```

  **Responses**:  
  - 200 OK: Task updated successfully.  
  - 404 Not Found: Task not found.  
  - 400 Bad Request: Invalid task data.

- **DELETE /api/tasks/{id}**  
  Deletes a task by its ID.  

  **Responses**:  
  - 200 OK: Task deleted successfully.  
  - 404 Not Found: Task not found.

### Task Status Management

- **PUT /api/tasks/{id}/complete**  
  Marks a task as complete.

  **Responses**:  
  - 200 OK: Task marked as complete.  
  - 404 Not Found: Task not found.

- **PUT /api/tasks/{id}/incomplete**  
  Marks a task as incomplete.

  **Responses**:  
  - 200 OK: Task marked as incomplete.  
  - 404 Not Found: Task not found.

### Filtering Tasks

- **GET /api/tasks/status**  
  Fetch tasks by completion status.  
  **Query Parameters**:  
  - `status=true` or `status=false`  

  **Responses**:  
  - 200 OK: Successfully retrieved tasks.  
  - 404 Not Found: No tasks found.

- **GET /api/tasks/date**  
  Fetch tasks by due date.  
  **Query Parameters**:  
  - `dueDate=yyyy-mm-dd`  

  **Responses**:  
  - 200 OK: Successfully retrieved tasks.  
  - 404 Not Found: No tasks found.

- **GET /api/tasks/priority**  
  Fetch tasks by priority level.  
  **Query Parameters**:  
  - `priority=0` (LOW) | `priority=1` (MED) | `priority=2` (HIGH)  

  **Responses**:  
  - 200 OK: Successfully retrieved tasks.  
  - 404 Not Found: No tasks found.

## Technologies

- **ASP.NET Core** for building the API.
- **AutoMapper** for mapping between DTOs and models.
- **Swashbuckle/Swagger** for API documentation.
- **CORS** for cross-origin requests.

## Setup

1. Clone this repository.
2. Run the project using Visual Studio or any .NET-compatible IDE.
3. Make sure your database is set up and connected.

## Example

### Get all tasks:

```bash
GET /api/tasks
```

**Response**:
```json
[
    {
        "Id": 1,
        "Title": "Task Title",
        "Description": "Task Description",
        "Status": false,
        "CreationDate": "2024-11-29",
        "DueDate": "2024-12-01",
        "Priority": 1
    }
]
```

### Create a new task:

```bash
POST /api/tasks
```

**Request Body**:
```json
{
    "Title": "New Task",
    "Description": "Task Description",
    "DueDate": "2024-12-01",
    "Priority": 2
}
```

**Response**:
```json
{
    "message": "Task created successfully."
}
```

## Contribution

Feel free to fork the repository, make changes, and submit pull requests. All contributions are welcome!

