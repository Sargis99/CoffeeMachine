using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;

namespace CoffeMaker
{
    public class SQLReader 
    {
      public int n; 
      public List<DB> CFD ;
      public User a;
 
        public SQLReader() 
        {
            CFD = new List<DB>();
            a = new User();
        }

        public void Start()
        {
            Create();
            int x;
            while (true)
            {
                Console.WriteLine("Press 1 to Insert coins press 0 to  end");
                x = Convert.ToInt16(Console.ReadLine());
                if (x == 1)
                {
                    Console.WriteLine("Enter the amount of the coin");
                    a.DepositCoin(Convert.ToInt16(Console.ReadLine()));
                        
                }

                if (x == 0)
                    break;

            }

            Check();
            Console.WriteLine("Enter the number of coffee ");
            a.MakeSelection(CFD[Convert.ToInt16(Console.ReadLine())-1]);
            Console.ReadLine();
            Console.Clear();
        }

        public void Create()
        {
            int i = 0;
            string connectionstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                string command = "select * from DBs";
                SqlCommand com = new SqlCommand(command, connection);

                SqlDataReader reader = com.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DB data = new DB((int)reader["ID"],(double)reader["WaterQu"],(double)reader["SugarQu"],(double)reader["CoffeeQu"],(int)reader["Price"]);
                        CFD.Add(data);
                        i++;
                    }
                }

                reader.Close();
            }
            n=i;
        }
        
        public void Check()
        {
            for (int i = 0; i < n; i++)
            {
                
                if (a.RunningTotal >= CFD[i].Price)
                {
                    Console.WriteLine("You can choose "+getCofee(i));
                }
                
            }
        }

        public string getCofee(int i)
        {
            return (CFD[i].CF_ID+"  "+CFD[i].Water_Qu+"  "+ CFD[i].Sugar_Qu+"  "+CFD[i].Coffe_Qu+"  "+CFD[i].Price);
        }
    }   
}