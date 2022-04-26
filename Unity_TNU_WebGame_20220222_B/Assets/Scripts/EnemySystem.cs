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

        private void Awake()
        {
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

        private void MoveToPlayer()
        {
            Vector3 posEnemy  = transform.position; // A�I : �ĤH�y��
            Vector3 posPlayer = traPlayer.position; // B�I : ���a�y��

            // �ĤH�y�� = ����(�ĤH�y�СA���a�y�СA�ʤ��� *�t�� * �@�V���ɶ�
            transform.position = Vector3.Lerp(posEnemy, posPlayer, 0.5f * data.speed * Time.deltaTime);

            // y = �ĤH X �j�� ���a X ? 180 : - �p�G�ĤH X �j�󪱮a X ���׳]�w�� 180 �_�h 0
            float y = transform.position.x > traPlayer.position.x ? 180 : 0;
            transform.eulerAngles = new Vector3(0, y, 0);
        }
    }
}