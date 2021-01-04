using MySql.Data.MySqlClient;
using System;
using PhoneBook.ViewModel;
using System.Collections;

namespace PhoneBook.DatabaseConnection
{
    class DataBaseConnection
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public DataBaseConnection()
        {
            Initialize();
        }
        //Initialize connection string
        private void Initialize()
        {
            server = "localhost";
            database = "csharpdatabase";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
        }
        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }

        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }
        //Check if database connection is ok
        public bool connectionCheck()
        {
            bool open = OpenConnection();
            bool close = CloseConnection();
            if (open && close) return true;
            else return false;
        }

        //create a table
        public bool createTable(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            try
            {
                OpenConnection();
                cmd.ExecuteNonQuery();
                CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString(), "Error in Database", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public void insertUserInfo(string username, string password)
        {
            string query = "INSERT INTO users (username, password) VALUES('" + username + "', '" + password + "')";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();
                //close connection
                this.CloseConnection();
            }
        }
        public bool ifUserExist(string username)
        {
            if (OpenConnection())
            {
                string query = "SELECT COUNT(*) FROM users WHERE username = '" + username + "';";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int count = reader.GetInt32(0);
                    if (count == 0)
                    {
                        CloseConnection();
                        return false;
                    }
                    else
                    {
                        CloseConnection();
                        return true;
                    }
                }
            }
            return false;
        }
        public int isUserValid(string username, string password)
        {
            if (OpenConnection())
            {
                string query = "SELECT id FROM users WHERE username = '" + username + "' and password = '" + password + "';";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int t = (int)reader["id"];
                    CloseConnection();
                    return t;
                }
            }
            return 0;
        }
        public bool saveContact(ContactViewModel cvm)
        {
            string query = "insert into contacts (name,num1,num2,num3,num4,num5,num6,email,street,city," +
                           "state,zip,country,about,_group,profilepic,userid) values ('" + cvm.name + "', '" + cvm.num1 + "'" +
                           " ,'" + cvm.num2 + "' , '" + cvm.num3 + "' , '" + cvm.num4 + "' , '" + cvm.num5 + "' , '" + cvm.num6 + "' ," +
                           " '" + cvm.email + "' , '" + cvm.street + "' , '" + cvm.city + "' , '" + cvm.state + "' , '" + cvm.zip + "' ," +
                           " '" + cvm.country + "' , '" + cvm.about + "' , '" + cvm.group + "' , '" + @cvm.image + "' ," +
                           " '" + cvm.uid + "')";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            try
            {
                OpenConnection();
                cmd.ExecuteNonQuery();
                CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString(), "Error in Database", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }

        }
        public ArrayList contactList(int suerid)
        {
            ArrayList list = new ArrayList();
            if (OpenConnection())
            {
                string query = "select id,name,num1 from contacts where userid = '" + suerid + "' order by name";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ContactViewModel cvm = new ContactViewModel();
                    cvm.Name = (string)reader["name"];
                    cvm.Number = (string)reader["num1"];
                    cvm.Initials = (cvm.Name[0].ToString() + cvm.Name[1].ToString()).ToUpper();
                    cvm.id = (int)reader["id"];
                    list.Add(cvm);
                }
            }
            CloseConnection();
            return list;
        }
        public ContactViewModel contactDetailsList(int id)
        {
            ContactViewModel cvm = new ContactViewModel();
            if (OpenConnection())
            {
                string query = "select * from contacts where id =  '" + id + "'";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cvm.name = (string)reader["name"];
                    cvm.num1 = (string)reader["num1"];
                    cvm.num2 = (string)reader["num2"];
                    cvm.num3 = (string)reader["num3"];
                    cvm.num4 = (string)reader["num4"];
                    cvm.num5 = (string)reader["num5"];
                    cvm.num6 = (string)reader["num6"];
                    cvm.email = (string)reader["email"];
                    cvm.street = (string)reader["street"];
                    cvm.city = (string)reader["city"];
                    cvm.zip = (string)reader["zip"];
                    cvm.state = (string)reader["state"];
                    cvm.country = (string)reader["country"];
                    cvm.about = (string)reader["about"];
                    cvm.group = (string)reader["_group"];
                    cvm.image = (string)reader["profilepic"];
                }
            }
            CloseConnection();
            return cvm;
        }

        public ArrayList contactSearch(int userid, string substring)
        {
            ArrayList list = new ArrayList();
            if (OpenConnection())
            {
                string query = "select id,name,num1,num2,num3,num4,num5,num6 from contacts where userid = '" + userid + "'  AND (name like '%" + substring + "%' OR num1 like '%" + substring + "%'  OR num1 like '%" + substring + "%' " +
                    " OR num2 like '%" + substring + "%' OR num3 like '%" + substring + "%' " +
                    " OR num4 like '%" + substring + "%' OR num5 like '%" + substring + "%' OR num6 like '%" + substring + "%')  order by name";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ContactViewModel cvm = new ContactViewModel();
                    cvm.Name = (string)reader["name"];

                    string temp1 = (string)reader["num1"];
                    string temp2 = (string)reader["num2"];
                    string temp3 = (string)reader["num3"];
                    string temp4 = (string)reader["num4"];
                    string temp5 = (string)reader["num5"];
                    string temp6 = (string)reader["num6"];
                    if (temp1.Contains(substring))
                    {
                        cvm.Number = temp1;
                    }
                    else if (temp2.Contains(substring))
                    {
                        cvm.Number = temp2;
                    }
                    else if (temp3.Contains(substring))
                    {
                        cvm.Number = temp3;
                    }
                    else if (temp4.Contains(substring))
                    {
                        cvm.Number = temp4;
                    }
                    else if (temp5.Contains(substring))
                    {
                        cvm.Number = temp5;
                    }
                    else if (temp6.Contains(substring))
                    {
                        cvm.Number = temp6;
                    }
                    else
                    {
                        cvm.Number= (string)reader["num1"];
                    }
                    cvm.Initials = (cvm.Name[0].ToString() + cvm.Name[1].ToString()).ToUpper();
                    cvm.id = (int)reader["id"];
                    list.Add(cvm);
                }
            }
            CloseConnection();
            return list;
        }
        public bool saveAppointment(AppointmentViewModel avm)
        {
            string quary = "insert into appointments (appointmentwith,title,dateandtime,details,userid) values('" + avm.AppointmentWith + "','" + avm.Title + "','" + avm.DateTime + "','" + avm.Details + "' , '"+avm.id+"')";
            MySqlCommand cmd = new MySqlCommand(quary, connection);
            try
            {
                OpenConnection();
                cmd.ExecuteNonQuery();
                CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString(), "Error in Database", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }


        public ArrayList appoinmentList(int suerid)
        {
            ArrayList list = new ArrayList();
            if (OpenConnection())
            {
                string query = "select id,appointmentwith,title,dateandtime from appointments where userid = '" + suerid + "' order by dateandtime";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AppointmentViewModel avm = new AppointmentViewModel();
                    avm.AppointmentWith = (string)reader["appointmentwith"];
                    avm.Title = (string)reader["title"];
                    avm.id = (int)reader["id"];
                    avm.DateTime = (string)reader["dateandtime"];
                    list.Add(avm);
                }
            }
            CloseConnection();
            return list;
        }

        public AppointmentViewModel getAppointmentDetails(int id)
        {
            AppointmentViewModel avm = new AppointmentViewModel();
            if (OpenConnection())
            {
                string query = "select appointmentwith,title,dateandtime,details from appointments where id= '"+ id +"'";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    avm.AppointmentWith = (string)reader["appointmentwith"];
                    avm.Title = (string)reader["title"];
                    avm.Details = (string)reader["details"];
                    avm.DateTime = (string)reader["dateandtime"];
                }
            }
            CloseConnection();
            return avm;
        }
        public ArrayList getAppointmentTimeList(int id)
        {
            ArrayList list = new ArrayList();
            if (OpenConnection())
            {
                string query = "select dateandtime,appointmentwith from appointments where userid = '" + id + "'";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AppointmentViewModel avm = new AppointmentViewModel();
                    avm.DateTime = (string)reader["dateandtime"];
                    avm.AppointmentWith = (string)reader["appointmentwith"];
                    list.Add(avm);
                }
            }
            CloseConnection();
            return list;
        }
        public bool isPasswordValid(int id,string Password)
        {
            if (OpenConnection())
            {
                string query = "SELECT COUNT(*) FROM users WHERE id = '" + id + "' and password = '" + Password + "';";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int count = reader.GetInt32(0);
                    if (count == 0)
                    {
                        CloseConnection();
                        return false;
                    }
                    else
                    {
                        CloseConnection();
                        return true;
                    }
                }
            }
            return false;
        }
        public bool updateUserPassword(int id, string password)
        {
            if (OpenConnection())
            {
                string query = "update users set password ='" + password + "' where id = '" + id + "'";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                CloseConnection();
                return true;
            }
            return false;
        }
        public bool deleteContact(int id)
        {
            if (OpenConnection())
            {
                string query = "delete from contacts where id = '" + id + "'";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                CloseConnection();
                return true;
            }
            return false;
        }

    }
}