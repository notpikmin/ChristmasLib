using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace ChristmasLib.Utils.Photon
{
    public static class PhotonUtils
    {
        
        public static T IL2CPPFromByteArray<T>(byte[] data)
        {
            if (data == null) return default;
            var bf = new Il2CppSystem.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            var ms = new Il2CppSystem.IO.MemoryStream(data);
            object obj = bf.Deserialize(ms);
            return (T)obj;
        }
        public static byte[] ToByteArray(Il2CppSystem.Object obj)
        {
            if (obj == null) return null;
            var bf = new Il2CppSystem.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            var ms = new Il2CppSystem.IO.MemoryStream();
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }

        public static byte[] ToByteArray(object obj)
        {
            if (obj == null) return null;
            var bf = new BinaryFormatter();
            var ms = new MemoryStream();
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }

        public static T FromByteArray<T>(byte[] data)
        {
            if (data == null) return default;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(data))
            {
                object obj = bf.Deserialize(ms);
                return (T)obj;
            }
        }
        public static T FromIL2CPPToManaged<T>(Il2CppSystem.Object obj)
        {
            return FromByteArray<T>(ToByteArray(obj));
        }

        public static T FromManagedToIL2CPP<T>(object obj)
        {
            return IL2CPPFromByteArray<T>(ToByteArray(obj));
        }

        public static void OpRaiseEvent(byte code, object customObject, RaiseEventOptions raiseEventOptions, SendOptions sendOptions)
        {
            Il2CppSystem.Object obj = FromManagedToIL2CPP<Il2CppSystem.Object>(customObject);
            OpRaiseEvent(code, obj, raiseEventOptions, sendOptions);
        }

        public static void OpRaiseEvent(byte code, Il2CppSystem.Object customObject, RaiseEventOptions raiseEventOptions, SendOptions sendOptions)
            => PhotonNetwork.Method_Public_Static_Boolean_Byte_Object_RaiseEventOptions_SendOptions_0
            (code,
                customObject,
                raiseEventOptions,
                sendOptions);


    }
}