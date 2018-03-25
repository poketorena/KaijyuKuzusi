using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Tank_Shell")
        {
            Debug.Log(">>>>>>>>>>>>>>>>>>>> Hit!");
            transform.localScale += new Vector3(1.0f, 1.0f, 1.0f);

            // 旧形式の書き方（動かないので機能が削除されたと考えられる）
            // rigidbody2D.AddForce(new Vector2(1000.0f, -1000.0f));
            
            // 新形式の書き方
            GetComponent<Rigidbody2D>().AddForce(new Vector2(1000.0f, -1000.0f));
        }
    }
}
