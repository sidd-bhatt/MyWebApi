namespace MyWebApi.DAL;
using System.Data;
using MySql.Data.MySqlClient;
using BOL;


public class StudentDetailsAccess
{

    public static string conString = @"server=localhost;port=3306;user=root;password=root@123;database=sidd";

    public static List<Students> ShowStudentsDetails()
    {
        List<Students> list = new List<Students>();
        MySqlConnection con = new MySqlConnection(conString);
        try
        {
            con.Open();
            string query = "select * from students";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int sid = int.Parse(reader["sid"].ToString());
                string? sname = reader["sname"].ToString();
                string? course = reader["course"].ToString();
                Students student = new Students
                {
                    Sid = sid,
                    Sname = sname,
                    Course = course
                };
                list.Add(student);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
        return list;
    }
    public static Students GetStudentById(int id)
    {
        Students students = null;
        MySqlConnection con = new MySqlConnection(conString);
        try
        {
            con.Open();
            string query = "select * from Students where sid=" + id;
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                students = new Students
                {
                    Sid = int.Parse(reader["sid"].ToString()),
                    Sname = reader["sname"].ToString(),
                    Course = reader["course"].ToString()
                };
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
        return students;

    }
    public static void DeleteUserById(int id)
    {
        MySqlConnection con = new MySqlConnection(conString);
        try
        {
            con.Open();
            string query = "delete from students where sid=" + id;
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    public static void InsertStudent(Students student)
    {
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            con.Open();
            string query = $"insert into students(sid,sname,course) values('{student.Sid}','{student.Sname}','{student.Course}')";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
    }

    public static void Update(Students student)
    {
        MySqlConnection con = new MySqlConnection(conString);
        try
        {
            string query = "UPDATE Students SET sname='" + student.Sname + "', course='" + student.Course + "' WHERE sid=" + student.Sid;
            MySqlCommand command = new MySqlCommand(query, con);
            con.Open();
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            con.Close();
        }
    }
}
