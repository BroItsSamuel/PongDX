using UnityEngine;

public class BallControl : MonoBehaviour {

    private Rigidbody2D _rb2D;

    void GoBall() {
        float rand = Random.Range (0, 2);
        if (rand < 1) {
            _rb2D.AddForce (new Vector2 (55, -40));
        } else {
            _rb2D.AddForce (new Vector2 (-55, -40));
        }
    }

    void Start () {
        _rb2D = GetComponent<Rigidbody2D> ();
        Invoke ("GoBall", 2);
    }

    void ResetBall() {
        _rb2D.velocity = new Vector2 (0, 0);
        transform.position = Vector2.zero;
    }

    void RestartGame() {
        ResetBall ();
        Invoke ("GoBall", 1);
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.collider.CompareTag ("Player")) {
            Vector2 vel;
            vel.x = _rb2D.velocity.x;
            vel.y = (_rb2D.velocity.y / 2.0f) + (coll.collider.attachedRigidbody.velocity.y / 3.0f);
            _rb2D.velocity = vel;
        }
    }

}