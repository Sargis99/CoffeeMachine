using System;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using System.Data.SqlClient;
using System.Configuration;

namespace CoffeMaker
{
       public class User
       {
           public int RunningTotal { set; get; }
           private SQLReader a;

           public User()
           {
               RunningTotal = 0;
           }

           public void DepositCoin(int money)
           {
               
                switch (money)
                {
                    case(50): RunningTotal += 50;
                        break;
                    case(100): RunningTotal += 100;
                        break;
                    case(200): RunningTotal += 200;
                        break;
                    case(500): RunningTotal += 500;
                        break;
                    default:
                        Console.WriteLine("Invalid entry try again");
                        break;             
                }
           }
           
          

           public void MakeSelection(DB c)
           {
               string connectionstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

               using (SqlConnection connection = new SqlConnection(connectionstring))
               {
                   connection.Open();
                   string selectQuerry = "select * from Storage";
                   SqlCommand command = new SqlCommand(selectQuerry, connection);
                   SqlDataReader reader = command.ExecuteReader();
                   CoffeeMachine cm = null;

                   if (reader.HasRows)
                   {
                       while (reader.Read())
                       {
                           cm = new CoffeeMachine((double) reader["Water"], (double) reader["Sugar"],
                               (double) reader["Coffee"]);
                       }
                   }

                   reader.Close();

                   if (c.Water_Qu <= cm.Water && c.Sugar_Qu <= cm.Sugar && c.Coffe_Qu <= cm.Coffee)
                   {
                       cm.Water -= c.Water_Qu;
                       cm.Sugar -= c.Sugar_Qu;
                       cm.Coffee -= c.Coffe_Qu;
                       Console.WriteLine("Your coffee is complet press 0 to take the change");
                       if (Convert.ToInt16(Console.ReadLine()) == 0)
                           Console.WriteLine("Your change is " + ReturningChange(c));

                       string updateQuerry =
                           $"update Storage set water = {cm.Water},  sugar = {cm.Sugar}, coffee = {cm.Coffee}";

                       SqlCommand com = new SqlCommand(updateQuerry, connection);

                       com.ExecuteNonQuery();
                   }
                   else
                   {
                       Console.WriteLine("Coffee machine is out of ingredients");
                   }

               }
           }

           private double ReturningChange(DB i)
           {
               if (RunningTotal > i.Price)
                   return (RunningTotal - i.Price);
               else return 0;

           }
           
           
    }
}