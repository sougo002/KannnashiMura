using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Test_CSV : MonoBehaviour {

	public enum LANG_MODE
	{
		JAPANESE,
		ENGLISH,
	}
	public enum CSV_NAME_NO
	{
		GREETING,
	}
	string[] CSV_NAME =
	{
		"Greeting",
	};

	private List<string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト
	private int height = 0; // CSVの行数

	void Start()
	{
		logSave(CSV_NAME_NO.GREETING, LANG_MODE.ENGLISH);
	}

	public void logSave(CSV_NAME_NO No, LANG_MODE Lang)
	{
#if skip
		StreamWriter sw;
		FileInfo fi;
		fi = new FileInfo(Application.dataPath + "/FileName.csv");
		sw = fi.AppendText();
		sw.WriteLine("test output");
		sw.Flush();
		sw.Close();
#endif

		string CsvName = CSV_NAME[(int)No]; // CSVファイル名
		string LangAdditional = GetLangAdd(Lang);
		TextAsset csvFile = Resources.Load("Csv/" + CsvName + LangAdditional) as TextAsset; // Resouces/CSV下のCSV読み込み
		StringReader reader = new StringReader(csvFile.text);

		while (reader.Peek() > -1)
		{
			string line = reader.ReadLine();
			csvDatas.Add(line.Split(',')); // リストに入れる
			height++; // 行数加算
		}

		//ログ出し
		DebugLog();
	}

	public string GetLangAdd(LANG_MODE Lang)
	{
		string Add = " - Japanese";
		switch (Lang)
		{
			case LANG_MODE.JAPANESE:
				Add = " - Japanese";
				break;
			case LANG_MODE.ENGLISH:
				Add = " - English";
				break;
		}
		return Add;
	}

	public void DebugLog()
	{
		Debug.Log("行数: " + height);
		for (int i=0; i<csvDatas.Count; i++)
		{
			Debug.Log(csvDatas[i][0]);
		}
	}
}
