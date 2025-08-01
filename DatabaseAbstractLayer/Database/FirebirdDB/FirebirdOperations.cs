﻿using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseAbstractLayer.Database.FirebirdDB
{
    public class FirebirdOperations
    {
        private FbConnection fbConnection;
        private string connectionString = "";
        private string userId = "";
        private string password = "";
        private string path = "";

        public void ConnectionString(string tmpUserId, string tmpPassw, string tmpPath)
        {
            userId = tmpUserId;
            password = tmpPassw;
            path = tmpPath;
        }

        public bool Open()
        {
            connectionString = @"User ID=" + userId + ";Password=" + password + ";Database=localhost:" + 
                               Application.StartupPath + "\\" + path + ";Charset=NONE;";
            fbConnection = new FbConnection(connectionString);
            fbConnection.Open();

            bool result = false;
            if (fbConnection.State == ConnectionState.Open)
                result = true;
            else
                result = false;

            return result;
        }

        public bool IsOpen()
        {
            if (fbConnection.State == ConnectionState.Open)
                return true;

            return false;
        }

        public void Close()
        {
            fbConnection.Close();
        }

        public bool Write(string commandString)
        {
            bool result = false;

            if (Open())
            {
                List<string> values = new List<string>();
                using (FbCommand command = new FbCommand(commandString, fbConnection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int fieldCount = reader.FieldCount;
                            for (int i = 0; i < fieldCount; i++)
                                values.Add(reader[i].ToString());
                        }
                    }
                }

                ProcedureOutput procedureOutput = ProcedureOutputResult(values);
                if (procedureOutput.StatusId >= 0)
                    result = true;
                else
                    result = false;

                Close();
            }
            else
            {
                result = false;
            }

            return result;
        }

        public List<string> Read(string commandString)
        {
            List<string> values = new List<string>();

            if (Open())
            {
                using (FbCommand command = new FbCommand(commandString, fbConnection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int fieldCount = reader.FieldCount;
                            for (int i = 0; i < fieldCount; i++)
                                values.Add(reader[i].ToString());
                        }
                    }
                }

                Close();
            }

            return values;
        }

        public static ProcedureOutput ProcedureOutputResult(List<string> values)
        {
            ProcedureOutput procedureOutput = new ProcedureOutput();

            if (values.Count > 0)
            {
                procedureOutput.StatusId = Convert.ToInt32(values[0]);
                procedureOutput.StatusMessage = Convert.ToInt32(values[1]);
                procedureOutput.ItemId = Convert.ToChar(values[2]);
                procedureOutput.DurationTime = values[3].ToString();
            }

            return procedureOutput;
        }
    }
}
