using System.Security.Principal;
using ToDoListAPI.Models;


namespace ToDoListAPI.Repo
{
    public class TaskRepo
    {
        protected TaskDBContext db;
        public TaskRepo(TaskDBContext db) { this.db = db; }

        public  List<TaskManagment> selectAllTasks()
        {
            return db.Tasks.ToList();
        }

        public TaskManagment selectTaskById(int id)
        {
            return db.Tasks.Find(id);
        }

        public void addTask(TaskManagment task)
        {
            db.Tasks.Add(task);
            //return entity;
        }

        public  void updateTask(TaskManagment task)
        {

            db.Entry(task).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //return entity;   
        }
        public  void removeTask(TaskManagment task)
        {

            db.Tasks.Remove(task);

        }

        public virtual void save()
        {

            db.SaveChanges();
        }

    }

}

