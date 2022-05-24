using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public BallMovement ballMovement;
    public ScoreController scoreController;

    void BounceFromPlayer(Collision2D player)
    {
        Vector3 ballPosition = this.transform.position;
        Vector3 playerPosition = player.gameObject.transform.position;

        float playerHeight = player.collider.bounds.size.y;

        float x;
        if (player.gameObject.name == "Player1")
            x = 1;
        else
            x = -1;

        float y = (ballPosition.y - playerPosition.y) / playerHeight;

        this.ballMovement.IncreaseHitCounter();
        this.ballMovement.MoveBall(new Vector2(x, y));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool isPlayer = collision.gameObject.name == "Player1" || collision.gameObject.name == "Player2";
        bool isWallLeft = collision.gameObject.name == "WallLeft";
        bool isWallRight = collision.gameObject.name == "WallRight";

        if (isPlayer)
            this.BounceFromPlayer(collision);
        else if (isWallLeft)
        {
            this.scoreController.GoalPlayer2();
            StartCoroutine(this.ballMovement.StartBall(true));
        }
        else if (isWallRight)
        {
            this.scoreController.GoalPlayer1();
            StartCoroutine(this.ballMovement.StartBall(false));
        }
    }
}
