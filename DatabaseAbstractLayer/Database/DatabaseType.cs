using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAbstractLayer.Database
{
    public class ProcedureOutput
    {
        public int StatusId { get; set; }
        public int StatusMessage { get; set; }
        public char ItemId { get; set; }
        public string DurationTime { get; set; }

        public ProcedureOutput()
        {
            try
            {
                StatusId = -1;
                StatusMessage = -1;
                ItemId = '0';
                DurationTime = "";
            }
            catch (Exception ex)
            {
            }
        }
    }

    public abstract class DatabaseType
    {
        public abstract bool Open();
        public abstract bool OpenState();
        public abstract void Close();
        public abstract void ConnectionString(string userId, string password, string path);
        public abstract bool CreateRecordData(RecordData recordData);
        public abstract bool InsertRecordData(RecordData recordData);
        public abstract List<RecordData> SelectRecordData(DateTime firstDateTime, DateTime secondDateTime);
        public abstract bool DeleteRecordData(int recordIndex);
    }
}
