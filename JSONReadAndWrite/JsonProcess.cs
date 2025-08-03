using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONReadAndWrite
{
    public class JsonData
    {
        public int value1 { get; set; }
        public int value2 { get; set; }
        public int value3 { get; set; }
    }

    public class JsonProcess
    {
        public int jsonId { set; get; }
        public JsonData[] jsonDatas = new JsonData[4];
        public string jsonFilePath = "JsonFile.json";

        public JsonProcess()
        {
            jsonId = 7;
            for (int i = 0; i < 4; i++)
            {
                jsonDatas[i] = new JsonData();
                jsonDatas[i].value1 = 0;
                jsonDatas[i].value2 = 0;
                jsonDatas[i].value3 = 0;
            }
        }

        public void ChangeJsonData(int tmpJsonId, int tmpValue1, int tmpValue2, int tmpValue3)
        {
            jsonDatas[tmpJsonId].value1 = tmpValue1;
            jsonDatas[tmpJsonId].value2 = tmpValue2;
            jsonDatas[tmpJsonId].value3 = tmpValue3;
        }

        public object[] JsonDataObjects()
        {
            object[] jsonObjects = new object[12];
            int index = 0;
            for (int i = 0; i < 12; i = i + 3)
            {
                jsonObjects[i] = jsonDatas[index].value1;
                jsonObjects[i + 1] = jsonDatas[index].value2;
                jsonObjects[i + 2] = jsonDatas[index].value3;
                index++;
            }

            return jsonObjects;
        }

        public void SaveJsonFile()
        {
            string data = Newtonsoft.Json.JsonConvert.SerializeObject(ControlParams.jsonProcess);
            File.WriteAllText(jsonFilePath, data);
        }

        public void ReadJsonFile()
        {
            string readJsonString = "";

            if (File.Exists(jsonFilePath))
            {
                readJsonString = File.ReadAllText(jsonFilePath);
                ControlParams.jsonProcess = Newtonsoft.Json.JsonConvert.DeserializeObject<JsonProcess>(readJsonString);
            }
            else
            {
                string writeJsonString = Newtonsoft.Json.JsonConvert.SerializeObject(ControlParams.jsonProcess);
                File.WriteAllText(jsonFilePath, writeJsonString);
                readJsonString = File.ReadAllText(jsonFilePath);
                ControlParams.jsonProcess = Newtonsoft.Json.JsonConvert.DeserializeObject<JsonProcess>(readJsonString);
            }
        }
    }
}
