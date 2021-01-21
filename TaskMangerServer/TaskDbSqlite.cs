using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Configuration;

namespace TaskMangerServer
{
    class TaskDbSqlite
    {
        readonly log4net.ILog log;
        //SQLiteConnection conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        public static string connection;
        // public static string connection =ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        SQLiteConnection conn;

        public TaskDbSqlite()
        {
            try
            {
                log = log4net.LogManager.GetLogger(typeof(TaskDbSqlite));
                connection = ConfigurationManager.AppSettings["con"].ToString();
                conn = new SQLiteConnection(connection);
            }
            catch (Exception ex)
            {
                
            }
        }
        public Task Create(Task task)
        {
            try
            {
                log.Debug("Sql Db create() Connection");
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(conn);
                cmd.CommandText = "INSERT INTO TaskManagerSql (Name,Status,Description,CreatedTime,EndTime) VALUES (@name,@status,@description,@createdTime,@endTime)";
                //cmd.CommandText = "INSERT INTO TaskManagerSql (Id,Name,Status,Description,CreatedTime,EndTime) VALUES (1,'task1','Open','Desc1','2021-01-11 01:01:01','2021-01-11 23:23:23')";
                cmd.Prepare();
              //  cmd.Parameters.AddWithValue("@id", task.id);
                cmd.Parameters.AddWithValue("@name", task.name);
                cmd.Parameters.AddWithValue("@status", task.status);
                cmd.Parameters.AddWithValue("@description", task.description);
                cmd.Parameters.AddWithValue("@createdTime", task.createdTime);
                cmd.Parameters.AddWithValue("@endTime", task.endTime);                
                cmd.ExecuteNonQuery();
                conn.Close();
                return task;
            }
            catch (Exception ex)
            {
                log.Error("Sql Db create() error");
                return null;
            }

        }
        public Task Edit(Task task)
        {
            try
            {
               
                log.Debug("Sql Db edit() connection");
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(conn);
                cmd.CommandText = "UPDATE TaskManagerSql SET Name = @N, Status = @S, Description = @D, CreatedTime = @C, EndTime = @E WHERE Id = @I";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@I", task.id);
                cmd.Parameters.AddWithValue("@N", task.name);
                cmd.Parameters.AddWithValue("@S", task.status);
                cmd.Parameters.AddWithValue("@D", task.description);
                cmd.Parameters.AddWithValue("@C", task.createdTime);
                cmd.Parameters.AddWithValue("@E", task.endTime);            
                cmd.ExecuteNonQuery();
                conn.Close();
                return task;
            }
            catch (Exception ex)
            {
                
               log.Error("Sql Db edit() error");
               return null;
            }
        }
        public int Delete(int id)
        {
            try
            {
                log.Debug("Sql Db delete() connection");
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(conn);
                cmd.CommandText = "Delete from TaskManagerSql  WHERE Id = @I";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@I", id);
                cmd.ExecuteNonQuery();
                conn.Close();
                return id;
            }
            catch (Exception ex)
            {
                log.Error("Sql Db delete() error");
                return 0;
            }
        }
        public List<Task> GetAll()
        {
            List<Task> tasklist = new List<Task>();
            try
            {
                log.Debug("Sql Db getall() error");
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(conn);
                cmd.CommandText = "Select Id,Name,Status,Description,CreatedTime,EndTime from TaskManagerSql";
                SQLiteDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    Task tk = new Task();
                    tk.id = Int32.Parse(reader["Id"].ToString());
                    tk.name = reader["Name"].ToString();
                    tk.status = reader["Status"].ToString();
                    tk.description = reader["Description"].ToString();
                    tk.createdTime = reader["CreatedTime"].ToString();
                    tk.endTime = reader["EndTime"].ToString();
                    tasklist.Add(tk);
                    
                }
                conn.Close();
                return tasklist;
            }
            catch (Exception ex)
            {
                log.Error("Sql Db getall() error");
                return null;
            }
        }
        public Task Get(int id)
        {
            try
            {
                log.Debug("Sql Db get() error");
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(conn);
                cmd.CommandText = "Select Id,Name,Status,Description,CreatedTime,EndTime from TaskManagerSql where id=" + id;
                var t = cmd.CommandText;
                SQLiteDataReader reader = cmd.ExecuteReader();
                Task tk = new Task();
                while (reader.Read())
                {
                    tk.id = Int32.Parse(reader["Id"].ToString());
                    tk.name = reader["Name"].ToString();
                    tk.status = reader["Status"].ToString();
                    tk.description = reader["Description"].ToString();
                    tk.createdTime = reader["CreatedTime"].ToString();
                    tk.endTime = reader["EndTime"].ToString();
                    //taskList.Add(tk);
                    
                }
                conn.Close();
                return tk;
            }
            catch (Exception)
            {
                log.Error("Sql Db get() error");
                return null;
            }
        }
    }
}
