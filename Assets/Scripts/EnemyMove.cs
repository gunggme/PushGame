using UnityEngine;
using UnityEngine.AI;   // ��ũ��Ʈ���� ������̼� �ý��� ����� ����Ϸ��� AI ���ӽ����̽��� using �����ؾ���
using static UnityEngine.GraphicsBuffer;

public class EnemyMove : MonoBehaviour
{
    // ���� ã�Ƽ� �̵��� ������Ʈ
    NavMeshAgent navMeshAgent;
    Animator animator;

    // ������Ʈ�� ������
    [SerializeField]
    Transform player;

    private void Awake()
    {
        // ������ ���۵Ǹ� ���� ������Ʈ�� ������ NavMeshAgent ������Ʈ�� �����ͼ� ����
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        EnemyMovement();
    }

    void EnemyMovement()
    {
        // ������Ʈ���� �������� �˷��ִ� �Լ�
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