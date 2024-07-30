// using System.IO;
// using System.Runtime.Serialization.Formatters.Binary;
// using UnityEngine;
//
// namespace ScriptableObjects.Old
// {
//     public abstract class PersistentScoreOld : ScriptableObject
//     {
//         public void Save(string nameFile=null)
//         {
//             var bf = new BinaryFormatter();
//             if (nameFile == null) return;
//             var file = File.Create(GetPath(nameFile));
//             var json = JsonUtility.ToJson(this);
//             bf.Serialize(file,json);
//             file.Close();
//         }
//
//         public virtual void Load(string nameFile=null)
//         {
//             if (!File.Exists(GetPath(nameFile))) return;
//             var bf = new BinaryFormatter();
//             var file = File.Open(GetPath(nameFile), FileMode.Open);
//             JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file),this);
//             file.Close();
//         }
//
//         private string GetPath(string nameFile=null)
//         {
//             var fullNameFile = string.IsNullOrEmpty(nameFile) ? name : nameFile;
//             return string.Format("{0}/{1}.txt", Application.persistentDataPath, fullNameFile);
//         }
//     }
// }