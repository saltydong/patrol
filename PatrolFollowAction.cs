using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolFollowAction : Action
{
    private float speed = 1.5f;          // 跟随玩家的速度
    private GameObject player;           // 玩家
    private PatrolData data;             // 巡逻兵数据

    public static PatrolFollowAction GetAction(GameObject player) {
        PatrolFollowAction action = CreateInstance<PatrolFollowAction>();
        action.player = player;
        return action;
    }

    public override void Start() {
        data = this.gameObject.GetComponent<PatrolData>();
    }

    public override void Update() {
        if (Director.GetInstance().CurrentSceneController.getGameState().Equals(GameState.RUNNING)) {
            // 追击玩家
            transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            this.transform.LookAt(player.transform.position);
    
            if (data.isFollowing && (!(data.isPlayerInRange && data.patrolRegion == data.playerRegion) || data.isCollided)) {
                this.destroy = true;
                this.enable = false;
                this.callback.ActionEvent(this);
                this.gameObject.GetComponent<PatrolData>().isFollowing = false;
                Singleton<GameEventManager>.Instance.PlayerEscape(this.gameObject);
            }
        }
    }
}
