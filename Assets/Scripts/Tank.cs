using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tank : MonoBehaviour
{
    // 毎回GetComponent<T>でコンポーネントを取ってくるのは探索コストが掛かってよくない気がする。
    // フィールドに参照を用意しておいてコンストラクタで代入しておいたほうがいい？


    GameObject goShell = null;
    bool action = false;

    // Use this for initialization
    void Start()
    {
        // 砲弾のゲームオブジェクト取得と砲弾の非表示設定

        // 旧形式の書き方（動きはするが使用厳禁）
        //goShell = transform.FindChild("Tank_Shell").gameObject;

        // 新形式の書き方
        goShell = transform.Find("Tank_Shell").gameObject;

        goShell.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // マウスが左クリックされたか？
        if (Input.GetMouseButton(0))
        {
            // タンクがクリックされたか？
            Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collition2d = Physics2D.OverlapPoint(tapPoint);
            if (collition2d)
            {
                if (collition2d.gameObject == gameObject)
                {
                    action = true; // アクションを有効にする
                }
            }
            if (action)
            {
                // タンク移動

                // 旧形式の書き方（動かないので機能が削除されたと考えられる）
                //rigidbody2D.AddForce(new Vector2(+30.0f, 0.0f));

                // 新形式の書き方
                GetComponent<Rigidbody2D>().AddForce(new Vector2(+30.0f, 0.0f));
            }
        }
        else
        {
            // マウスの左ボタンが離されたか？
            if (Input.GetMouseButtonUp(0) && action)
            {
                if (goShell)
                {
                    goShell.SetActive(true);

                    // 旧形式の書き方（動かないので機能が削除されたと考えられる）
                    //goShell.rigidbody2D.AddForce(new Vector2(+300.0f, 500.0f));

                    // 新形式の書き方
                    goShell.GetComponent<Rigidbody2D>().AddForce(new Vector2(+300.0f, 500.0f));

                    // 3秒経過したらオブジェクトを削除
                    Destroy(goShell.gameObject, 3.0f);
                }
                action = false;
            }
        }
    }

    void OnGUI()
    {
        GUI.TextField(new Rect(10, 10, 300, 60),
                "[Unity 2Dでゲームを作る本 Sample 2-1]\n戦車をクリックすると加速\n離すと発射！");
        if (GUI.Button(new Rect(10, 80, 100, 20), "リセット"))
        {
            // 非推奨の書き方
            //Application.LoadLevel(Application.loadedLevelName);

            // こっちのほうが新しい書き方なのでこっちを使うべき
            SceneManager.LoadScene("MainGame");
        }
    }
}
