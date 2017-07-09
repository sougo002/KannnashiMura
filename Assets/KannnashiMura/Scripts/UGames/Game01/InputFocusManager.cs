using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UGames.Game01
{
    /// <summary>
    /// フォーカス対象を管理するマネージャ。
    /// 入力を必要とするスクリプトはInputFocusManagerに自分をフォーカスに登録して、使い終わったら登録解除すること.
    /// ex) 
    /// var focusMgr = InputFocusManager.Instance;
    /// focusMgr.Register(this); // 登録
    /// if (focusMgr.GetCurrent() == this) {} //ボタン入力などを受けつける前にフォーカスが自分かチェック
    /// focusMgr.Unregister(this); // 登録解除
    /// (フォーカスが自オブジェクトじゃないけど自分への入力を許容したいときに面倒だけど、我慢してクレメンス)
    /// </summary>
    public class InputFocusManager : SingletonMonoBehaviour<InputFocusManager>
    {

        /// <summary>
        /// フォーカススタック
        /// </summary>
        protected Stack<MonoBehaviour> focusStack;

        /// <summary>
        /// 登録されいるフォーカス対象の数
        /// </summary>
        public int Count {
            get {
                return this.focusStack.Count;
            }
        }

        override protected void Awake()
        {
            base.Awake();

            focusStack = new Stack<MonoBehaviour>();
        }

        /// <summary>
        /// 現在のフォーカス対象を取得する.
        /// </summary>
        /// <returns>現在のフォーカス対象</returns>
        public MonoBehaviour GetCurrent()
        {
            if (this.focusStack.Count == 0)
            {
                return null;
            }
            return this.focusStack.Peek();
        }

        /// <summary>
        /// 指定したMonoBehaviourをフォーカスのスタックに登録する。
        /// </summary>
        /// <param name="monoBehaviour"></param>
        public void Register(MonoBehaviour monoBehaviour)
        {
            if (monoBehaviour == null)
            {
                throw new global::System.ArgumentNullException();
            }
            this.focusStack.Push(monoBehaviour);
        }


        /// <summary>
        /// 指定したMonoBehaviourが現在のフォーカスであった場合、スタックから登録解除する。
        /// そうでない場合、なにもしない。
        /// </summary>
        /// <param name="monoBehaviour">登録解除する対象</param>
        /// <returns>成功可否</returns>
        public bool Unregister(MonoBehaviour monoBehaviour)
        {
            if (this.focusStack.Count == 0)
            {
                return false;
            }
            if (this.focusStack.Count == 0)
            {
                return false;
            }
            if (this.focusStack.Peek() != monoBehaviour)
            {
                return false;
            }
            this.focusStack.Pop();
            return true;
        }
    }
}