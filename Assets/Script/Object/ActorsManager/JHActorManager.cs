using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JHActorManager : MonoBehaviour
{
    /////////////////////////////////////////////////////////////////////////
    // Varaibles
    public static JHActorManager instance = null;       // singleton

    public Transform _baseObject_Worker;                // baseobject. 인스펙터에서 초기화

    [SerializeField] private GameObject _pfNullWorker;	// Null 워커 프리팹

    public int _workerCount;                           // 일꾼 개수. init 초기화

    private List<GameObject> _actorList_Worker;         // 액터Worker 게임오브젝트를 들고있는 리스트.

    /////////////////////////////////////////////////////////////////////////
    // Methods
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        this.InitValue();

        //this.UpdateValue();
    }

    /// <summary>
    /// 초기값 불러오기.
    /// </summary>
    private void InitValue()
    {
        this._actorList_Worker = new List<GameObject>();
        this._workerCount = JHGameVariableManager.instance.LoadIntVariable(JHEnum.VariableType.eUserWorkerCount);
    }

    /// <summary>
    /// 현재 세팅된 변수들로 상태 업데이트.
    /// </summary>
    private void UpdateValue()
    {
        Debug.Log("!! Actor 전체스폰 시작 !!");

        // 일꾼 세팅 파트
        for (int workerIdx = 0; workerIdx < this._workerCount; workerIdx++)
        {
            this.SpawnActor((int)JHEnum.ActorKey.eActorNullWorker);
        }
        
        // 다른거 세팅 파트 예시
        /*
        for (int workerIdx = 0; workerIdx < this._workerCount; workerIdx++)
        {
            this.SpawnActor((int)JHEnum.ActorKey.eActorNullWorker);
        }
        */
    }

    public void SpawnNullWorker()
    {
        IncreaseNullWorker();
    }

    /// <summary>
    /// Actor 타입에 맞게 스폰시키는 함수.
    /// 성공적으로 스폰되었다면 eTypeSuccess 을 반환.
    /// </summary>
    /// <param name="actorKey"></param>
    /// <returns></returns>
    public int SpawnActor(int actorKey)
    {
        if ((int)JHEnum.ActorKey.eActorNullWorker == actorKey)
        {
            GameObject go = Instantiate(this._pfNullWorker, this._baseObject_Worker) as GameObject;

            if (null == go)
            {
                Debug.Log("Actor_Worker 스폰에 문제발생!!");
                return (int)JHEnum.rvType.eTypeFail;
            }

            //Set Position
            float xPos = 10000;
            float yPos = 10000;

            // 포지션 세팅, 액터키 세팅
            go.GetComponent<JHActor>().SetActorPos(xPos, yPos);
            go.GetComponent<JHActor>().SetActorKey(actorKey);

            // 리스트에 반영
            _actorList_Worker.Add(go);

            return (int)JHEnum.rvType.eTypeSuccess;
        }
        else
        {
            return (int)JHEnum.rvType.eTypeFail;
        }
    }


    /// <summary>
    /// Null일꾼 증가시키기. 
    /// </summary>
    public void IncreaseNullWorker()
    {
        //Null Worker가 이미 존재하나? 그러면 더 Spawn안함.
        if (GameObject.FindGameObjectWithTag("NullWorker") != null)
        {
            Debug.Log("이미 널 워커가 존재합니다!");
            return;
        }
        // 임시워커 스폰 시도
        int rv = this.SpawnActor((int)JHEnum.ActorKey.eActorNullWorker);

        // 스폰에 문제가 있나?
        if (0 != rv)
        {
            return;
        }


    }

    /// <summary>
	/// 일꾼 증가시키기. 임시함수
	/// </summary>
	public void IncreaseWorker()
    {
        // 임시워커 스폰 시도
        int rv = this.SpawnActor((int)JHEnum.ActorKey.eActorNullWorker);

        // 스폰에 문제가 있나?
        if (0 != rv)
        {
            return;
        }
    }

    /// <summary>
    /// 일꾼 모두 죽이기. 임시함수
    /// 적당히 참고만 하고 이 함수는 지우자.
    /// </summary>
    public void KillAllWorker()
    {
        // 걍 모든 리스트를 돌면서 지운다.
        for (int idx = 0; idx < this._actorList_Worker.Count; idx++)
        {
            Destroy(_actorList_Worker[idx].gameObject);
        }

        // 메모리에 반영 시도.
        this._workerCount = 0;

        // 유저데이터에 작성.
        JHGameVariableManager.instance.SaveVariable(JHEnum.VariableType.eUserWorkerCount, this._workerCount);
    }

}
