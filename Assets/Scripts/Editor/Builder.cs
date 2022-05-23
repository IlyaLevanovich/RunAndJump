using UnityEditor;
using UnityEditor.Build.Reporting;

namespace Assets.Scripts.Editor
{
    public static class Builder
    {
        [MenuItem("Build/Android")]
        public static void BuildAndroid()
        {
            var process = BuildPipeline.BuildPlayer(
                new BuildPlayerOptions
                {
                    target = BuildTarget.Android,
                    locationPathName = "C:/JobProjects/Other/RunAndJump/Builds/Game.apk",
                    scenes = new[] { "Assets/Scenes/Game.unity" }
                });

            if (process.summary.result == BuildResult.Failed)
                throw new System.Exception("Build failed. See console for more details.");

        }
    }
}