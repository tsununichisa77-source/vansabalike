using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
[SerializeField] StatusData statusdata;
public SpriteRenderer spriteRenderer;
private float currentTime;
[SerializeField]GameObject punch;
[SerializeField] Sprite imageIdle;
[SerializeField] Sprite imagePunch;
Vector3 worldAngle;//角度を代入する

void Start(){
    spriteRenderer = GetComponent<SpriteRenderer>();
    spriteRenderer.sprite = imageIdle; // 待機状態の画像
    punch.GetComponent <BoxCollider2D>().enabled = false; // Punchの当たり判定をなくす
}
 void Update()
    {
        currentTime+=Time.deltaTime;
        // myTransform = this.transform;
        // myPos= this.transform.position;
        if (Input.GetKey(KeyCode.W)) {//wが押されている時に実行される
            if (this.transform.position.y < 5)  {
                transform.position += new Vector3(0, statusdata.SPEED * Time.deltaTime, 0);//☑
            }
        }
        if (Input.GetKey(KeyCode.S)){//sが押されている時に実行される
            if (this.transform.position.y > -5) { 
                transform.position += new Vector3(0, -1* statusdata.SPEED * Time.deltaTime, 0);//☑
            }
        }
        if (Input.GetKey(KeyCode.A)) {//aが押されている時に実行される
            if (this.transform.position.x > -3) { 
                worldAngle.y = 0f;//通常の向き
                this.transform.localEulerAngles = worldAngle;//自分の角度に代入する
                transform.position += new Vector3(-1 * statusdata.SPEED * Time.deltaTime, 0, 0);//☑
            }
        }
        if (Input.GetKey(KeyCode.D)) {//dが押されている時に実行される
            if (this.transform.position.x < 3) { 
                worldAngle.y = -180f;//右向きの角度
                this.transform.localEulerAngles = worldAngle;//自分の角度に代入
                transform.position += new Vector3(statusdata.SPEED * Time.deltaTime, 0, 0);//☑
            }
        }
        if (currentTime > statusdata.SPAN)//2秒ごとに実行される
        {
            spriteRenderer.sprite = imagePunch;//Playerの画像を攻撃用の画像に切り替える
            punch.GetComponent<BoxCollider2D>().enabled = true;//あたり判定をつける
            StartCoroutine("Punchswitch");//攻撃を持続させるためのコルーチンを起動する
            currentTime = 0f;
        }
    }
    IEnumerator Punchswitch()
    {   
            spriteRenderer.sprite = imagePunch;
            yield return new WaitForSeconds(1);//1秒後に下の2行を実行する
            spriteRenderer.sprite = imageIdle;//待機状態の画像に切り替える
            punch.GetComponent<BoxCollider2D>().enabled = false;//あたり判定をなくす
    }
}