using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
//using System.Web.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Net.Mail;


namespace Connect2LeadsLeadProcess.DataAccess
{
    public class MySQLAccess
    {   //used as proxy to interact with MySQL database

        
        public MySqlConnection GetConnection(string connectstring)
        {
            try
            {

            MySqlConnection retCon = null;

            retCon = new MySql.Data.MySqlClient.MySqlConnection(connectstring);

            return retCon;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Int64 executeNonQuery(string theNonQuery,string theConnectStringName)
        {
            ///generic function to execute SQL command 
            Int32 recsAffected = 0;//this will hold the number of records affected by the nonQuery command
            try
            {
                
                // Create and open the connection in a using block. This
                // ensures that all resources will be closed and disposed
                // when the code exits. Use the connect string from above.
                using (MySql.Data.MySqlClient.MySqlConnection myCON = GetConnection(theConnectStringName))
                {
                    myCON.Open();
                    //string InsertTme = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    MySqlCommand myCommand = new MySqlCommand(theNonQuery, myCON);
                    recsAffected=myCommand.ExecuteNonQuery();
                    
                }

                return recsAffected;

            }
            catch (Exception e)
            {
                
                throw;
                
            }
            

        }
        public void getDataSet(string theQuery, string theConnectStringName)
        {
            //generic get data set 
             try
            {
                

                // Create and open the connection in a using block. This
                // ensures that all resources will be closed and disposed
                // when the code exits. Use the connect string from above.
                using (MySql.Data.MySqlClient.MySqlConnection myCON = GetConnection(theConnectStringName))
                {
                    myCON.Open();
                    //string InsertTme = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    MySqlCommand myCommand = new MySqlCommand(theQuery, myCON);
                    MySqlDataReader myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}",
                            myReader[0], myReader[1], myReader[2]);
                         Console.WriteLine(myReader.GetInt32(0) + ", " + myReader.GetString(1));
                    }
                    Console.ReadLine();
                }

                

            }
             catch (Exception e)
             {

                 throw;

             }
            
        }

        

        public DataSet getLeadsToPost(string theConnectString)
        {

            //returns security_key,campaign_id,phone,extern_id,de_dupe,list_name,
            //first_name,middle_name,last_name,address1,address2,city,
            //state,zip,aux_data1,aux_data2,aux_data3,aux_data4,aux_data5 ,email,gate_keeper



            //get all leads to post
            string theCommand = "getLeadsToPost";

            try
            {
                

                // Create and open the connection in a using block. This
                // ensures that all resources will be closed and disposed
                // when the code exits. Use the connect string from above.
                using (MySql.Data.MySqlClient.MySqlConnection myCON = GetConnection(theConnectString))
                {
                    myCON.Open();
                    MySqlCommand myCommand = new MySqlCommand(theCommand, myCON);
                    myCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    
                    //create data adapter and assign the command object created above
                    MySqlDataAdapter myAdapter = new MySqlDataAdapter();
                    myAdapter.SelectCommand = myCommand;
                    //create and fill a dataset from the stored procedure
                    DataSet theLeadsToPost = new DataSet();
                    myAdapter.Fill(theLeadsToPost);



                    return theLeadsToPost;

                

                    
                }



            }
            catch (Exception e)
            {
                //if error then return null
                return null;

            }

        }



        public int savePostResult(string theClientLeadID, string thePostresult, string isSuccess, string theConnectString)
        {


            
            //save a record of all lead posts
            string theCommand = "savePostResult";
            Int32 recsAffected = 0;//this will hold the number of records affected by the nonQuery command
            try
            {

                // Create and open the connection in a using block. This
                // ensures that all resources will be closed and disposed
                // when the code exits. Use the connect string from above.
                using (MySql.Data.MySqlClient.MySqlConnection myCON = GetConnection(theConnectString))
                {
                    myCON.Open();
                    //string InsertTme = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    MySqlCommand myCommand = new MySqlCommand(theCommand, myCON);
                    myCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    //add input parameters
                    MySqlParameter myInParam1 = new MySqlParameter();
                    myInParam1.ParameterName = "theClientLeadID";
                    myInParam1.Value = theClientLeadID;
                    myCommand.Parameters.Add(myInParam1);
                    myInParam1.Direction = System.Data.ParameterDirection.Input;
                    //add input parameters
                    MySqlParameter myInParam2 = new MySqlParameter();
                    myInParam2.ParameterName = "thePostresult";
                    myInParam2.Value = thePostresult;
                    myCommand.Parameters.Add(myInParam2);
                    myInParam2.Direction = System.Data.ParameterDirection.Input;
                    //add input parameters
                    MySqlParameter myInParam3 = new MySqlParameter();
                    myInParam3.ParameterName = "isSuccess";
                    myInParam3.Value = isSuccess;
                    myCommand.Parameters.Add(myInParam3);
                    myInParam3.Direction = System.Data.ParameterDirection.Input;
                    
                    
                    recsAffected = myCommand.ExecuteNonQuery();
                }

                return recsAffected;

            }
            catch (Exception e)
            {
                return recsAffected;
                //string theexception = e.Message.ToString();
                throw;

            }


        }



    
    
    
    }



}