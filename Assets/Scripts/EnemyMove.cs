using UnityEngine;
using UnityEngine.AI;   // 스크립트에서 내비게이션 시스템 기능을 사용하려면 AI 네임스페이스를 using 선언해야함
using static UnityEngine.GraphicsBuffer;

public class EnemyMove : MonoBehaviour
{
    // 길을 찾아서 이동할 에이전트
    NavMeshAgent navMeshAgent;
    Animator animator;

    // 에이전트의 목적지
    [SerializeField]
    Transform player;

    private void Awake()
    {
        // 게임이 시작되면 게임 오브젝트에 부착된 NavMeshAgent 컴포넌트를 가져와서 저장
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        EnemyMovement();
    }

    void EnemyMovement()
    {
        // 에이전트에게 목적지를 알려주는 함수
        if (Vector3.Distance(this.transform.position, player.position) < navMeshAgent.stoppingDistance + 0.5f)
        {
            navMeshAgent.isStopped = true;
            animator.SetBool("isMove", false);
        }
        else
        {
            navMeshAgent.isStopped = false;
            navMeshAgent.SetDestination(player.position);
            animator.SetBool("isMove", true);
        }
    }
}