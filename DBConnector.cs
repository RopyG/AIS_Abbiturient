using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Security.Cryptography;
using System.Threading;
using System.IO;
using System.Data.Common;

namespace AIS
{
    public class DBConnector
    {
        private SqlConnection connection;
        //public void Connect(CommonDataContainer ab)
        //{

        //    SqlConnection sqlConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\corse\\Database1.mdf;Integrated Security=True");
        //    sqlConnection.Open();
        //    SqlCommand com;
        //    com.Parameters.
        //    //new SqlCommand($"INSERT INTO Clients(Login, FirstName, LastName, TrainingProgram, FormOfTraining, Base, Direction, PhoneNumber) VALUES('{abb.Login}', '{abb.FirstName}', '{abb.LastName}', '{abb.TrainingProgram}', '{abb.FormOfTraining}', '{abb.Base}', '{abb.Direction}', '{abb.PhoneNumber}');", sqlConnection).ExecuteNonQuery();
        //    sqlConnection.Close();
        //}

        public DBConnector()
        {
#if DEBUG
            string workingDirectory = Environment.CurrentDirectory;
            string path = Directory.GetParent(workingDirectory).Parent.FullName;
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
#endif
#if !DEBUG
            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
#endif
        }
        public void CreateAccount(string login, string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Abbiturients.mdf;Integrated Security=True";
            conn.Open();
            var command = new SqlCommand($"INSERT INTO Accounts (Login, Password) VALUES (@login, @password);", connection);
            command.Parameters.Add("@login", SqlDbType.NChar);
            command.Parameters["@login"].Value = login;
            command.Parameters.Add("@password", SqlDbType.NVarChar);
            command.Parameters["@password"].Value = savedPasswordHash;
            command.ExecuteNonQuery();
            conn.Close();
        }

        public bool Login(string login, string password)
        {
            if (login.Length < 1 || password.Length < 1)
                return false;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Abbiturients.mdf;Integrated Security=True";
            conn.Open();
            SqlCommand command = new SqlCommand("Select Password FROM Accounts Where login = @login", connection);
            command.Parameters.Add("@login", SqlDbType.NChar);
            command.Parameters["@login"].Value = login;
            string savedPasswordHash;
            /* Fetch the stored value */
            using (SqlDataReader reader = command.ExecuteReader())
            {
                // if the result set is not NULL
                if (!reader.HasRows)
                {
                    return false;
                }
                else
                {
                    reader.Read();
                    savedPasswordHash = reader.GetString(0);
                }
            }
            /* Extract the bytes */
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
            /* Get the salt */
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            /* Compute the hash on the password the user entered */
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            /* Compare the results */
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                {
                    MessageBox.Show("Incorrect login or password", "Authentication has failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                    return false;
                }
            conn.Close();
            return true;
        }


        private void Disconnect(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }
        public void Connect(System.Windows.Forms.Form formm)
        {
            formm.FormClosing += Disconnect;
            connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Abbiturients.mdf;Integrated Security=True");
            if (IsAvailable())
            {
                connection.Open();
            }
        }
        private bool IsAvailable()
        {
            try
            {
                connection.Open();
                connection.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Data Base is unavailable", "DB connection failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public bool IsAccountValid(string username, string password, string role)
        {
            SqlConnection securityConnection = new SqlConnection();
            string sql_command = "SELECT count(*) FROM Accounts WHERE name = @username;";
            bool SqlUserExists;

            SqlCommand command = new SqlCommand(sql_command, connection);
            command.Parameters.Add("@username", SqlDbType.NChar);
            command.Parameters["@username"].Value = username;

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (reader.GetValue(0).ToString() == "1")
                    {
                        SqlUserExists = true;
                    }
                }
            }

            SqlUserExists = false;

            if (SqlUserExists)
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = "Data Source=.;" + "User id=" + username + ";Password=" + password + ";";
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    MessageBox.Show("Data Base is unavailable", "DB connection failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connection.Dispose();
                    return false;
                }

            }
            else
            {
                return true;
            }
        }



        public void InsertAbbiturient(string firstName, string lastName, string trainingProgram, string formOfTraining, string _base, string direction, string phoneNumber, string scores)
        {
            var command = new SqlCommand("INSERT INTO CLIENTS (FirstName, LastName, TrainingProgram, FormOfTraining, Base, Direction, PhoneNumber, Scores) " +
                "VALUES (@firstName, @lastName, @trainingProgram, @formOfTraining, @_base, @direction, @phoneNumber, @scores);", connection);

            //command.Parameters.Add("@login", SqlDbType.NChar);
            //command.Parameters["@login"].Value = Id;

            command.Parameters.Add("@firstName", SqlDbType.NChar);
            command.Parameters["@firstName"].Value = firstName;

            command.Parameters.Add("@lastName", SqlDbType.NChar);
            command.Parameters["@lastName"].Value = lastName;

            command.Parameters.Add("@trainingProgram", SqlDbType.NChar);
            command.Parameters["@trainingProgram"].Value = trainingProgram;

            command.Parameters.Add("@formOfTraining", SqlDbType.NChar);
            command.Parameters["@formOfTraining"].Value = formOfTraining;

            command.Parameters.Add("@_base", SqlDbType.NChar);
            command.Parameters["@_base"].Value = _base;

            command.Parameters.Add("@direction", SqlDbType.NChar);
            command.Parameters["@direction"].Value = direction;

            command.Parameters.Add("@phoneNumber", SqlDbType.NChar);
            command.Parameters["@phoneNumber"].Value = phoneNumber;

            command.Parameters.Add("@scores", SqlDbType.NChar);
            command.Parameters["@scores"].Value = scores;
            command.ExecuteNonQuery();
        }

        public void InsertAbbiturient(Abbiturient abb)
        {
            Connect(new SimulationForm());
            var command = new SqlCommand("INSERT INTO CLIENTS (FirstName, LastName, TrainingProgram, FormOfTraining, Base, Direction, PhoneNumber, Scores) " +
                "VALUES (@firstName, @lastName, @trainingProgram, @formOfTraining, @_base, @direction, @phoneNumber, @scores);", connection);

            //command.Parameters.Add("@login", SqlDbType.NChar);
            //command.Parameters["@login"].Value = login;
            
            command.Parameters.Add("@firstName", SqlDbType.NChar);
            command.Parameters["@firstName"].Value = abb.FirstName;

            command.Parameters.Add("@lastName", SqlDbType.NChar);
            command.Parameters["@lastName"].Value = abb.LastName;

            command.Parameters.Add("@trainingProgram", SqlDbType.NChar);
            command.Parameters["@trainingProgram"].Value = abb.TrainingProgram;

            command.Parameters.Add("@formOfTraining", SqlDbType.NChar);
            command.Parameters["@formOfTraining"].Value = abb.FormOfTraining;

            command.Parameters.Add("@_base", SqlDbType.NChar);
            command.Parameters["@_base"].Value = abb.Base;

            command.Parameters.Add("@direction", SqlDbType.NChar);
            command.Parameters["@direction"].Value = abb.Direction;

            command.Parameters.Add("@phoneNumber", SqlDbType.NChar);
            command.Parameters["@phoneNumber"].Value = abb.PhoneNumber;

            command.Parameters.Add("@scores", SqlDbType.NChar);
            command.Parameters["@scores"].Value = abb.Scores;
            command.ExecuteNonQuery();
        }
        public void FReach ( CommonDataContainer labb)
        {
            for(int i = 0; i<labb.Abbiturients.Count; i++)
            {
                InsertAbbiturient(labb.Abbiturients[i]);
                //Thread.Sleep(3000);
                Task.Delay(1000);
            }
        }

        public void SelectAbbiturientAll()
        {
            string sql = "Select Id, FirstName, LastName, TrainingProgram, FormOfTraining, Direction, Base from Clients";

            // Создать объект Command.
            SqlCommand cmd = new SqlCommand();
            if (!Directory.Exists("C:\\Doc"))
                Directory.CreateDirectory("C:\\Doc");
            // Сочетать Command с Connection.
            cmd.Connection = connection;
            cmd.CommandText = sql;
            int count = 0;
            string date = DateTime.Now.ToString();
            date = date.Remove(10);
            string path = $"C:\\Doc\\Запись всех программ({date}).txt";
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    using (var ds = new StreamWriter(path))
                    {
                        ds.WriteLine($"Дата создания:{date}");
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader.GetValue(0));
                            string firstname = reader.GetString(1);
                            string lastname = reader.GetString(2);
                            string trainingprogram = reader.GetString(3);
                            int empNameIndex = reader.GetOrdinal("FormOfTraining");
                            string trainingofform = reader.GetString(empNameIndex);
                            int dir = reader.GetOrdinal("Direction");
                            string direction = reader.GetString(dir);
                            int mngId = reader.GetOrdinal("Base");
                            string _base = reader.GetString(mngId); 

                            ds.WriteLine($"-№{count += 1}------------------");
                            ds.WriteLine("ID:" + id);
                            ds.WriteLine("Имя:" + firstname);
                            ds.WriteLine("Фамилия:" + lastname);
                            ds.WriteLine("Программа обучения:" + trainingprogram);
                            ds.WriteLine("Форма обучения:" + trainingofform);
                            ds.WriteLine("Направление:" + direction);
                            ds.WriteLine("Основа:" + _base);
                        }
                    }
                }
            }
        }
        /*Id, FirstName, LastName, TrainingProgram, FormOfTraining, Direction, Base*/

        public void SelectAbbiturientCertainProg_Ob(ComboBox Prog_Ob)
        {
            string sql = $"Select Id, FirstName, LastName, TrainingProgram, FormOfTraining, Direction, Base from Clients WHERE TrainingProgram = N'{Prog_Ob.Text}';";
            // Создать объект Command.
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (!Directory.Exists("C:\\Doc"))
                Directory.CreateDirectory("C:\\Doc");
            // Сочетать Command с Connection.
            //cmd.Connection = connection;
            //cmd.CommandText = sql//$"Select FirstName, LastName, TrainingProgram, FormOfTraining, Direction, Base from Clients where TrainingProgram='{Prog_Ob.Text.ToString()}'";
            int count = 0;
            string date = DateTime.Now.ToString();
            date = date.Remove(10);
            string path = $"C:\\Doc\\Конкретная программа обучения({date}).txt";

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    using (var ds = new StreamWriter(path))
                    {
                        ds.WriteLine($"Программма:{Prog_Ob.Text}");
                        ds.WriteLine($"Дата создания:{date}");
                        while (reader.Read())
                        {
                            // Индекс столбца Emp_ID в команде SQL.
                            int id = Convert.ToInt32(reader.GetValue(0));


                            //long empId = Convert.ToInt64(reader.GetValue(0));

                            // Столбец Emp_No имеет index = 1.
                            string firstname = reader.GetString(1);
                            string lastname = reader.GetString(2);
                            //string trainingprogram = reader.GetString(3);
                            int empNameIndex = reader.GetOrdinal("FormOfTraining");// 2
                            string trainingofform = reader.GetString(empNameIndex);

                            int dir = reader.GetOrdinal("Direction");
                            string direction = reader.GetString(dir);
                            // Индекс столбца Mng_Id в команде SQL.
                            int mngId = reader.GetOrdinal("Base");
                            string _base = reader.GetString(mngId); ;
                            //long? mngId = null;
                            ds.WriteLine($"-№{count += 1}------------------");
                            ds.WriteLine("ID:" + id);
                            ds.WriteLine("Имя:" + firstname);
                            ds.WriteLine("Фамилия:" + lastname);
                            //ds.WriteLine("Программа обучения:" + trainingprogram);
                            ds.WriteLine("Форма обучения:" + trainingofform);
                            ds.WriteLine("Направление:" + direction);
                            ds.WriteLine("Основа:" + _base);

                        }
                    }    
                     
                }
            }
        }


        

        public void SelectAbbiturientCertainProg_ObAndCertainDirection(ComboBox Prog_Ob, ComboBox Direction)
        {
            string sql = "Select Id, FirstName, LastName, TrainingProgram, FormOfTraining, Base, Direction from Clients where TrainingProgram=N'" + Prog_Ob.SelectedItem + "' and Direction=N'" + Direction.SelectedItem + "'";
            // Создать объект Command.
            SqlCommand cmd = new SqlCommand();
            if (!Directory.Exists("C:\\Doc"))
                Directory.CreateDirectory("C:\\Doc");
            // Сочетать Command с Connection.
            cmd.Connection = connection;
            cmd.CommandText = sql;
            int count = 0;
            string date = DateTime.Now.ToString();
            date = date.Remove(10);
            string path = $"C:\\Doc\\Конкретная программа;направление({date}).txt";

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    using (var ds = new StreamWriter(path))
                    {
                        ds.WriteLine($"Программма:{Prog_Ob.Text}");
                        ds.WriteLine($"Направление:{Direction.Text}");
                        ds.WriteLine($"Дата создания:{date}");
                        while (reader.Read())
                        {
                            // Индекс столбца Emp_ID в команде SQL.
                            int id = Convert.ToInt32(reader.GetValue(0)); // 0


                            //long empId = Convert.ToInt64(reader.GetValue(0));

                            // Столбец Emp_No имеет index = 1.
                            string firstname = reader.GetString(1);
                            string lastname = reader.GetString(2);
                            //string trainingprogram = reader.GetString(3);
                            int empNameIndex = reader.GetOrdinal("FormOfTraining");// 2
                            string trainingofform = reader.GetString(empNameIndex);
                            string direction = reader.GetString(6);
                            // Индекс столбца Mng_Id в команде SQL.
                            int mngId = reader.GetOrdinal("Base");
                            string _base = reader.GetString(mngId); ;
                            //long? mngId = null;

                            ds.WriteLine($"-№{count += 1}------------------");
                            ds.WriteLine("ID:" + id);
                            ds.WriteLine("Имя:" + firstname);
                            ds.WriteLine("Фамилия:" + lastname);
                            //ds.WriteLine("Программа обучения:" + trainingprogram);
                            ds.WriteLine("Форма обучения:" + trainingofform);
                            //ds.WriteLine("Направление:" + direction);
                            ds.WriteLine("Основа:" + _base);
                        }
                    }
                }
            }
        }
        public void SelectAbbiturientEnrollment(ComboBox Prog_Ob, ComboBox Direction, TextBox abitrValues)
        {
            string sql = $"Select TOP ({abitrValues.Text})Id, FirstName, LastName, TrainingProgram, FormOfTraining, Direction, Base, Scores from Clients WHERE TrainingProgram = N'{Prog_Ob.Text}' and Direction = N'{Direction.Text}' ORDER BY Scores DESC;";
            // Создать объект Command.
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (!Directory.Exists("C:\\Doc"))
                Directory.CreateDirectory("C:\\Doc");
            // Сочетать Command с Connection.
            //cmd.Connection = connection;
            //cmd.CommandText = sql//$"Select FirstName, LastName, TrainingProgram, FormOfTraining, Direction, Base from Clients where TrainingProgram='{Prog_Ob.Text.ToString()}'";
            int count = 0;
            string date = DateTime.Now.ToString();
            date = date.Remove(10);
            string path = $"C:\\Doc\\Зачисление({date}).txt";

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    using (var ds = new StreamWriter(path))
                    {
                        ds.WriteLine($"Программма:{Prog_Ob.Text}");
                        ds.WriteLine($"Направление:{Direction.Text}");
                        ds.WriteLine($"Дата создания:{date}");
                        while (reader.Read())
                        {
                            // Индекс столбца Emp_ID в команде SQL.
                            int id = Convert.ToInt32(reader.GetValue(0));


                            //long empId = Convert.ToInt64(reader.GetValue(0));

                            // Столбец Emp_No имеет index = 1.
                            string firstname = reader.GetString(1);
                            string lastname = reader.GetString(2);
                            //string trainingprogram = reader.GetString(3);
                            int empNameIndex = reader.GetOrdinal("FormOfTraining");// 2
                            string trainingofform = reader.GetString(empNameIndex);
                            
                            //int dir = reader.GetOrdinal("Direction");
                            //string direction = reader.GetString(dir);
                            // Индекс столбца Mng_Id в команде SQL.
                            int mngId = reader.GetOrdinal("Base");
                            string _base = reader.GetString(mngId); ;
                            int score = Convert.ToInt32(reader.GetValue(7)); 
                            //long? mngId = null;
                            ds.WriteLine($"-№{count += 1}------------------");
                            ds.WriteLine("ID:" + id);
                            ds.WriteLine("Имя:" + firstname);
                            ds.WriteLine("Фамилия:" + lastname);
                            //ds.WriteLine("Программа обучения:" + trainingprogram);
                            ds.WriteLine("Форма обучения:" + trainingofform);
                            //ds.WriteLine("Направление:" + direction);
                            ds.WriteLine("Основа:" + _base);
                            ds.WriteLine("Баллы:" + score);

                        }
                    }

                }
            }
        }

    }
}
