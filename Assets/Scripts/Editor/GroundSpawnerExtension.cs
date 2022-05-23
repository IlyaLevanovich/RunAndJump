using Assets.Scripts.Infrastructure;
using System.Diagnostics;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Editor
{
    public static class GroundSpawnerExtension
    {
        [MenuItem("Tools/Open GroundSpawner config file")]
        public static void OpenConfigFile()
        {
            var filePath = Path.Combine(Application.streamingAssetsPath, "SpawnParameters.json");
            Process.Start("notepad.exe", filePath);
        }
    }
}