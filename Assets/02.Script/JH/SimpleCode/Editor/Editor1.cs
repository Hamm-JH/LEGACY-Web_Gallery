using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;

public class Editor1 : EditorWindow
{
	private DefaultAsset targetFolder = null;

	[MenuItem ("Window/Folder Selection Example")]
	public static void ShowWindow()
	{
		EditorWindow.GetWindow(typeof(Editor1));
	}

	private void OnGUI()
	{
		targetFolder = (DefaultAsset)EditorGUILayout.ObjectField(
			"Select Folder",
			targetFolder,
			typeof(DefaultAsset),
			false
			);

		if(targetFolder != null)
		{
			EditorGUILayout.HelpBox(
				"Valid folder! Name : " + targetFolder.name,
				MessageType.Info,
				true
				);
		}
		else
		{
			EditorGUILayout.HelpBox(
				"Not valid!",
				MessageType.Warning,
				true
				);
		}
	}


	[MenuItem("MyMenu/Do Something")]
    static void DoSomething()
	{

	}

	[MenuItem("MyMenu/Log Selected Transform Name")]
	static void LogSelectedTransformName()
	{
		Debug.Log(Application.dataPath);

		string SourcePath = Application.dataPath + @"/Resources/Test/";
		string DestPath = Application.dataPath + @"/Resources/Copied/";

		string[] files = Directory.GetFiles(SourcePath);
		
		foreach(var file in files)
		{
			//Debug.Log($"File name : {file.Split('/').Last()}");
			//Debug.Log($"File path : {file}");   // D:/Dev2/Web_Gallery/Assets/Resources/Test/492.jpg	// 이미지 경로

			string extension = "";
			if (file.Split('.').Last() == "meta")
			{
				extension = "jpg.meta";
			}
			else
			{
				extension = "jpg";
			}

			string fileName = file.Split('/').Last();
			string replacedFileName = $"{fileName.Substring(0, 3)}.{extension}";

			//Debug.Log(file);
			//Debug.Log($"111 File name : {fileName}");
			//Debug.Log($"222 Replaced File name : {replacedFileName}");

			string destFile = Path.Combine(DestPath, replacedFileName);

			if(!File.Exists(destFile))
			{
				FileUtil.CopyFileOrDirectory(file, destFile);
			}
			else
			{
				Debug.LogWarning($"destFile : {destFile} already exist");
			}
		}
	}
}
