using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolData : MonoBehaviour
{
    public bool isPlayerInRange;    // 是否侦测
    public bool isFollowing;        // 是否追击
    public bool isCollided;         // 是否碰撞
    public int patrolRegion;        // 区域
    public int playerRegion;        // 玩家区域
    public GameObject player;       // 追击玩家
}
