using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAbstractLayer.Database.FirebirdDB
{
    public class SelectData
    {
        public int Data1 { get; set; }
        public double Data2 { get; set; }
        public string Data3 { get; set; }
    }

    public class FirebirdProcess : DatabaseType
    {
        private FirebirdOperations firebirdOperations = new FirebirdOperations();
        private readonly string createRecordCommand = "create ...";
        private readonly string insertRecordCommand = "insert ...";
        private readonly string selectRecordCommand = "select ...";
        private readonly string deleteRecordCommand = "delete ...";

        public override bool Open()
        {
            return firebirdOperations.Open();
        }

        public override bool OpenState()
        {
            bool state = firebirdOperations.IsOpen();
            return state;
        }

        public override void Close()
        {
            firebirdOperations.Close();
        }

        public override void ConnectionString(string userId, string passw, string path)
        {
            firebirdOperations.ConnectionString(userId, passw, path);
        }

        public override bool CreateRecordData(RecordData recordData)
        {
            string command = createRecordCommand + "('" + recordData.Value1 + "','" + recordData.Value2 + "','" + 
                             DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + "');";
            bool result = firebirdOperations.Write(command);

            return result;
        }

        public override bool InsertRecordData(RecordData recordData)
        {
            string command = insertRecordCommand + "('" + ConvertRecordDataToJson(recordData) + "');";
            bool result = firebirdOperations.Write(command);

            return result;
        }

        public override List<RecordData> SelectRecordData(DateTime firstDateTime, DateTime secondDateTime)
        {
            List<RecordData> recordDataList = new List<RecordData>();
            string command = selectRecordCommand + "('" + firstDateTime.ToString("dd.MM.yyyy 00:00:00") + "','" + 
                             secondDateTime.ToString("dd.MM.yyyy 23:59:59") + "');";
            List<string> data = firebirdOperations.Read(command);

            if (data.Count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    RecordData recordData = ConvertJsonToRecordData(data[i]);
                    recordDataList.Add(recordData);
                }
            }

            return recordDataList;
        }

        public override bool DeleteRecordData(int recordIndex)
        {
            string command = deleteRecordCommand + "(" + recordIndex.ToString() + ");";
            bool result = firebirdOperations.Write(command);

            return result;
        }

        private string ConvertRecordDataToJson(RecordData recordData)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(recordData);
        }

        private RecordData ConvertJsonToRecordData(string value)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<RecordData>(value);
        }
    }
}
