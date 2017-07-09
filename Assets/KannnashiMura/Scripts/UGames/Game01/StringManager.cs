using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UGames.Game01
{
    /// <summary>
    /// 文字列リソースの管理を行うクラス。
    /// 「Resouces/Strings/[language]」に配置されたCSVを読み込みます。
    /// ※GetString(string)は、引数にはID文字列を直に書くのではなく、StringIDクラスのフィールドを使ってください。
    /// ex) 
    /// var stringMgr = StringManager.Instance;
    /// stringMgr.GetString(StringID.HOGEHOGE);
    /// ※制約事項※ 現状カンマとダブルクォーテーションは使えません。。。。
    /// </summary>
    public class StringManager : SingletonMonoBehaviour<StringManager>
    {
        private CSVParser currentCSV;
        private Dictionary<string, string> stringsDictionary = new Dictionary<string, string>();

        /// <summary>
        /// UGames.Game01.Languageと同じ順番で定義すること
        /// </summary>
        private string[] fileNames = {
            "Japanese",
            "English"
         };

        private Language language = Language.Japanese;

        /// <summary>
        /// 現在設定されている言語
        /// </summary>
        public Language CurrentLanguage {
            get {
                return language;
            }
        }

        override protected void Awake()
        {
            base.Awake();
            this.load();
        }
        
        /// <summary>
        /// 言語を設定しCSVから文字列情報をロードする
        /// </summary>
        /// <param name="language">言語</param>
        public void SetLanguage(Language language)
        {
            if (this.fileNames.Length <= (int)language)
            {
                throw new System.ArgumentException("指定言語に対応するファイル名が宣言されてません");
            }
            this.language = language;
            this.load();
        }

        /// <summary>
        /// 指定IDの文字列を取得する。
        /// 直接呼ばないで、StringIDの定数を使ってください。
        /// </summary>
        /// <param name="id">文字列ID</param>
        /// <returns></returns>
        public string GetString(string id)
        {
            if (id == null)
            {
                throw new System.ArgumentNullException("Nullはダメ");
            }
            string result;
            if (stringsDictionary.TryGetValue(id, out result))
            {
                return result;
            }
            else
            {
                throw new System.Exception("ID\"" + id + "\"に紐づく文字列が見つかりませんでした。");
            };
        }

        /// <summary>
        /// 文字列IDのリストを取得する。
        /// </summary>
        /// <returns></returns>
        public List<string> GetIDList()
        {
            return new List<string>(stringsDictionary.Keys);
        }

        private void load()
        {
            var filename = this.fileNames[(int)language];

            // Resouces/Strings/[language].csvの読み込み
            TextAsset csvFile = Resources.Load("Strings/" + filename) as TextAsset; 
            var csv = new CSVParser(csvFile);

            for (var i = 0; i < csv.RowCount; i++)
            {
                var row = csv.GetRow(i);
                // CSVの情報が完全じゃない場合はその行を無視する
                if (row.Count < 2 || row[0] == null || row[0] == "")
                {
                    continue;
                }
                try
                {
                    stringsDictionary.Add(row[0], row[1]);
                } catch (ArgumentException e)
                {
                    
                    Debug.LogError("文字列ID[" + row[0] + "]が重複しているため、スキップします。");
                }
            }
            this.currentCSV = csv;
        }
    }
}
