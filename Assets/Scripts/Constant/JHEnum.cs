using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JHEnum : MonoBehaviour
{

    // 게임데이터 저장 타입
    public enum VariableType
    {
        eUserMoney = 0,                 // 돈

        eFarmFieldCount = 100,          // FarmField 개수 

        eUserWorkerCount = 200,         // 일꾼 개수'

        eUserFertilizer = 201,           // 인벤토리 ( 비료 )

        eUserDebt = 300,                // 빚

        eUserDate = 400,                // 게임 상의 시간
    }

    // 액터 움직입 타입
    public enum ActorMoveType
    {
        eMoveNone = 0,                  // 안 움직이는 상태
        eMoveRoaming = 1,               // 로밍. 무작위로 움직이는 상태
    }

    // return value 타입
    public enum rvType
    {
        eTypeSuccess = 0,               // 무난히 성공
        eTypeFail = 1,                  // 치명적인 실패
    }

    // 액터키 모음. 추후 이걸 데이터로 빼는작업 필요.
    public enum ActorKey
    {
        eActorNullWorker = 10,          // 임시 워커
        
    }

    // 현재 액터의 상태를 정의해놓음.
    public enum ActorState
    {
        eActorStateNone = 0,            // 아무상태도 아님
        eActorStateIdle = 1,            // 대기상태
        eActorStateMoving = 2,          // 움직이는 상태
    }


    // Initial Date(게임 시작했을 때의 날짜)
    public enum InitialDate
    {
        eInitYear = 2019,
        eInitMonth = 3,
        eInitDay = 1,
        eInitHour = 6,
    }
   
}

