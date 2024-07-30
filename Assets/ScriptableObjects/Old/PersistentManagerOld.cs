// using System.Collections.Generic;
// using UnityEngine;
//
// namespace ScriptableObjects.Old
// {
//     public class PersistentManagerOld : MonoBehaviour
//     {
//         public List<PersistentScore> objectsToSave;
//
//         public void OnEnable()
//         {
//             foreach (var scriptableObject in objectsToSave)
//             {
//                 scriptableObject.Load();
//             }
//         }
//
//         public void OnDisable()
//         {
//             foreach (var scriptableObject in objectsToSave)
//             {
//                 scriptableObject.Save();
//             }
//         }
//     }
//     
// }