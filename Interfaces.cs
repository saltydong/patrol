using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActionEventType : int { Started, Completed } // 事件类型
public enum GameState { RUNNING, PAUSE, START, LOSE, WIN } // 游戏状态

public interface SceneController
{
    void LoadResources();          
    int GetScore();                  
    GameState getGameState();       
    void setGameState(GameState gs); 
    void Restart();                 
    void Pause();                    
    void Begin();                    
}

public interface UserAction
{
 
    void MovePlayer(float translationX, float translationZ);
}

public interface ActionCallback
{
    void ActionEvent(Action source, ActionEventType events = ActionEventType.Completed,
        int intParam = 0, string strParam = null, object objectParam = null);
}
