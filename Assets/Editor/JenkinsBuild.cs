using System.Collections.Generic;
using System.Linq;
using UnityEditor;

public static class JenkinsBuild
{
  [MenuItem("Build/ApplicationBuild/Android")]
  public static void BuildAndroid()
  {
     //AndroidにSwitch Platform
     EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android, BuildTarget.Android);

     var scene_name_array = CreateBuildTargetScenes().ToArray();
     PlayerSettings.applicationIdentifier = "com.hogehoge.fugafuga";
     PlayerSettings.productName = "jenkins test";
     PlayerSettings.companyName = "Graffity";
     
     //Splash Screenをオフにする(Personalだと動かないよ）
     PlayerSettings.SplashScreen.show = false;
     PlayerSettings.SplashScreen.showUnityLogo = false;
     
     //AppBundleは使用しない（本番ビルドのときだけ使うイメージ）
     EditorUserBuildSettings.buildAppBundle = false;

     BuildPipeline.BuildPlayer(scene_name_array,"Build.apk" , BuildTarget.Android, BuildOptions.Development);
  }

  #region Util
  
  private static IEnumerable<string> CreateBuildTargetScenes()
  {
     foreach (var scene in EditorBuildSettings.scenes)
     {
        if (scene.enabled)
           yield return scene.path;
     }
  }

  #endregion
}