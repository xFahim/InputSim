using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace InputSim
{
    public class BinaryserializerHelper
    {
        /// <summary>
        /// Returns 1 if the process id successful 
        /// Returns 0 if binary serialization process fails somehow
        /// Returns -1 if a file with the same name already exists (process fail) [which means the tag given for the input set is not unique]
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int SerializeObj(object obj,string fpath)
        {
            if (!Directory.Exists("Records"))
            {
                Directory.CreateDirectory("Records");
            }

            if (File.Exists(fpath))
            {
                return -1;
            }
            else
            {

                try
                {
                    using (FileStream fs = File.Create(fpath))
                    {
                        BinaryFormatter bf = new BinaryFormatter();

                        bf.Serialize(fs, obj);

                        return 1;
                    }
                }
                catch
                {
                    return 0;
                }
                
            }
        }

        public static object DeserializeObj(string fpath)
        {
            object obj = null;

            if (File.Exists(fpath))
            {
                FileStream fs = File.Open(fpath, FileMode.Open);

                BinaryFormatter bf = new BinaryFormatter();
                obj = bf.Deserialize(fs);

                fs.Close();
            }

            return obj;
        }

        public static List<InputSetData> GetAllSerializedData()
        {
            List<InputSetData> _inpSetList = new List<InputSetData>();

            if (Directory.Exists("Records"))
            {
                foreach (string s in Directory.GetFiles("Records"))
                {
                    _inpSetList.Add((InputSetData)DeserializeObj(s));
                }
            }

            return _inpSetList;
        }
    }
}
