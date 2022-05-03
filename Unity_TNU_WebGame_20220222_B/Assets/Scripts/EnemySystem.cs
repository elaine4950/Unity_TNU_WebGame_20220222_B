using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MengFan
{
    ///<summary>
    /// �ĤH�t��
    /// </summary>
    public class EnemySystem : MonoBehaviour
    {
        [SerializeField, Header("�ĤH���")]
        private DataEnemy data;
        [SerializeField, Header("���a����W��")]
        private string namePlayer = "�߫}";

        private Transform traPlayer;
        /// <summary>
        /// �����p�ɾ�
        /// </summary>
        private float timerAttack;
        private Animator ani;
        private string parameterAttack = "Ĳ�o����";


        private void Awake()
        {
            ani = GetComponent<Animator>();
            // ���a�ܧ� = �C������.�M��(����W��) �� �ܧ�
            traPlayer = GameObject.Find(namePlayer).transform;

            // �ƾ�.����(A�AB�A�ʤ���)
            float result = Mathf.Lerp(0, 100, 0.5f);
            print("0 �P 100 �� 0.5 ���ȵ��G:" + result);

        }

        float a = 0;
        float b = 1000;

        private void Update()
        {
            /**���մ���
            a = Mathf.Lerp(a, b, 0.5f);
            print("���յ��G:" + a);
            */
            MoveToPlayer();
        }

        public void OnDrawGizmos()
        {
            Gizmos.color = new Color(1, 0.5f, 0, 0.5f);
            Gizmos.DrawSphere(transform.position, data.stopDistance);
        }

        private void MoveToPlayer()
        {
            Vector3 posEnemy  = transform.position; // A�I : �ĤH�y��
            Vector3 posPlayer = traPlayer.position; // B�I : ���a�y��

            //�Z�� = �T��V�q.�Z��(A�I�AB�I)
            float dis = Vector3.Distance(posEnemy, posPlayer);
            //print("<color=yellow>�Z��:" + dis + "</color>");

            //�p�G �Z�� �p�� ����Z�� �N�B�z -
            if (dis < data.stopDistance)
            {
                Attack();
            }
            //�_�h �Z�� �j�� ����Z�� �N�B�z �l��
            else
            {
                // �ĤH�y�� = ����(�ĤH�y�СA���a�y�СA�ʤ��� *�t�� * �@�V���ɶ�
                transform.position = Vector3.Lerp(posEnemy, posPlayer, 0.5f * data.speed * Time.deltaTime);

                // y = �ĤH X �j�� ���a X ? 180 : - �p�G�ĤH X �j�󪱮a X ���׳]�w�� 180 �_�h 0
                float y = transform.position.x > traPlayer.position.x ? 180 : 0;
                transform.eulerAngles = new Vector3(0, y, 0);
            }
        }
        private void Attack()
        {
            if(timerAttack < data.cd)
            {
                timerAttack += Time.deltaTime;
                print("<color=red>�����p�ɾ�:" + timerAttack + "</color>");
            }
            else
            {
                ani.SetTrigger(parameterAttack);
                timerAttack = 0;
            }
        }
    }
}