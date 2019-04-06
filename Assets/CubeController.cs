using System.Collections;
using UnityEngine;

public class CubeController : MonoBehaviour {

    // キューブの移動速度
    private float speed = -0.2f;

    // 消滅位置
    private float deadLine = -10;

    // "AudioSource"コンポーネントを格納する変数
    private AudioSource audioSource;

    // Use this for initialization
    void Start() {
        // "AudioSource"コンポーネントを変数"audioSource"に格納する
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {

        // キューブを移動させる
        transform.Translate(this.speed, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine) {
            Destroy(gameObject);
        }
    }

    // キューブが地面に接触する時と積み重なるときに効果音
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "GroundTag" || collision.gameObject.tag == "CubeTag") {
            GetComponent<AudioSource>().Play();
            Debug.Log(collision.gameObject.name);
        }
    }
}