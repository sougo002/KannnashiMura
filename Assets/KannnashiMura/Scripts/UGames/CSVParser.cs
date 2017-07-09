using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// CSVをパースして値を取りやすくするクラス.
/// ※セルがダブルクォーテーション「""」でくくられたCSVを想定。
/// </summary>
/// 
namespace UGames
{
    public class CSVParser
    {
        private TextAsset target;

        private List<string[]> csvDatas = new List<string[]>();
        private char delimiter = ',';

        /// <summary>
        /// 行数
        /// </summary>
        public int RowCount {
            get {
                return this.csvDatas.Count;
            }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="csv">パース対象のCSV</param>
        public CSVParser(TextAsset csv)
        {
            if (csv == null)
            {
                throw new System.Exception();
            }
            this.target = csv;
            this.parse();
        }

        /// <summary>
        /// セルを取得する
        /// </summary>
        /// <param name="col">列</param>
        /// <param name="row">行</param>
        /// <returns>文字列</returns>
        public string GetCell(int col, int row)
        {
            if (row < 0 || this.csvDatas.Count <= row)
            {
                return "";
            }
            if (col < 0 || this.csvDatas[row].Length <= col)
            {
                return "";
            }
            return this.csvDatas[row][col];
        }

        /// <summary>
        /// 指定行の文字列Listを取得する
        /// </summary>
        /// <param name="row">行</param>
        /// <returns>文字列List</returns>
        public List<string> GetRow(int row)
        {
            if (row < 0 || this.csvDatas.Count <= row)
            {
                return new List<string>();
            }
            return new List<string>(this.csvDatas[row]);
        }

        /// <summary>
        /// 指定列の文字列Listを取得する
        /// </summary>
        /// <param name="col">列</param>
        /// <returns>文字列List</returns>
        public List<string> GetColmn(int col)
        {
            if (col < 0)
            {
                return new List<string>();
            }
            var columnList = new List<string>();
            for (var i = 0; i < this.csvDatas.Count; i++)
            {
                if (col < this.csvDatas[i].Length)
                {
                    columnList.Add(this.csvDatas[i][col]);
                }
                else
                {
                    columnList.Add("");
                }

            }
            return columnList;
        }

        private void parse()
        {
            if (this.target == null)
            {
                throw new System.Exception();
            }
            this.csvDatas = new List<string[]>();
            StringReader reader = new StringReader(target.text);

            while (reader.Peek() > -1)
            {
                string line = reader.ReadLine();
                string[] colmuns = line.Split(this.delimiter);

                // 前後の空白を除去
                for (var i = 0; i < colmuns.Length; i++)
                {
                    colmuns[i] = colmuns[i].Trim();
                }
                csvDatas.Add(colmuns); // リストに入れる
            }
        }
    }
}