using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Il2CppSystem;
namespace ChristmasLib.Utils
{
    public static class SerializationUtils
    {
        public static byte[] ToByteArray(Il2CppSystem.Object o)
        {
            if(o == null){return null;}

            BinaryFormatter bFormatter = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();

            bFormatter.Serialize(memStream, o);
            return memStream.ToArray();
        }

        public static byte[] ToByteArray(object o)
        {
            if (o == null) { return null; }

            BinaryFormatter bFormatter = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();

            bFormatter.Serialize(memStream, o);
            return memStream.ToArray();
        }
        public static T FromByteArray<T>(byte[] data)
        {
            if (data == null){return default(T);}
            BinaryFormatter binFormatter = new BinaryFormatter();
            using (MemoryStream memStream = new MemoryStream(data))
            {
                T final = (T)((object)binFormatter.Deserialize(memStream));
                return final;
            }
        }

        public static T IL2CPPFromByteArray<T>(byte[] data)
        {
            if (data == null) { return default(T); }

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream(data);
            return (T)((object)binaryFormatter.Deserialize(memoryStream));
        }

        public static T IL2CPPToMono<T>(Il2CppSystem.Object o)
        {
            return FromByteArray<T>(ToByteArray(o));
        }

        public static T MonoToIL2CPP<T>(object o)
        {
            return IL2CPPFromByteArray<T>(ToByteArray(o));
        }

    }
}
