using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    //ゲームスコアを表示するテキスト
    private GameObject scoreText;

    int score = 0;

    // Use this for initialization
    void Start () {
        //シーンの中のGameoverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        //シーンの中のscoreTextオブジェクトを取得
        this.scoreText = GameObject.Find("SCORE");

    }

    // Update is called once per frame
    void Update () {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ) {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }

    }
    //衝突時に呼ばれる関数
    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag== "SmallStarTag"){
            score += 10;
        }else if(collision.gameObject.tag=="LargeStarTag"){
            score += 20;
        }else if(collision.gameObject.tag== "SmallCloudTag"){
            score += 30;
        }else if(collision.gameObject.tag== "LargeCloudTag")
        {
            score += 40;
        }

        //soreTextにスコアを表示
        this.scoreText.GetComponent<Text>().text = "score="+score;
    }

}
