using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MengFan
{
    public class WeaponSystem : MonoBehaviour
    {
        [SerializeField, Header("�Z�����")]
        private DataWeapon dataWeapon;

        /// <summary>
        /// �p�ɾ�
        /// </summary>
        private float timer;
        // ø�s�ϥܨƥ� ODG
        // ���� : �b�s�边�����U�ΡA�����Ҥ����|�X�{
        private void OnDrawGizmos()
        {
            // 1.�M�w�C��
            // Color(���A��A�šA�z����) - 0 ~ 1
            Gizmos.color = new Color(1, 0, 0, 0.5f);
            // 2. ø�s�ϥ�
            // �ϥ� ø�s�y��(�����I�A�b�|)
            // ���o�}�C��ƻP�k : �}�C��ƦW��[���ޭ�]

            // for �j�� : ���ƳB�z�{���϶�
            // (��l�� ; ���� ; �j�鵲���|����{��)
            for (int i = 0; i < dataWeapon.v35pawnPoint.Length; i++)
            {
                Gizmos.DrawSphere(transform.position + dataWeapon.v35pawnPoint[i], 0.1f);
            }
            
        }

        private void Start()
        {
            // 2D ���z.�����ϼh�I��(�ϼh1�A�ϼh2)
            Physics2D.IgnoreLayerCollision(3, 6); // ���a �P �Z�� ���I��
            Physics2D.IgnoreLayerCollision(6, 6); // �Z�� �P �Z�� ���I��
            Physics2D.IgnoreLayerCollision(6, 7); // �Z�� �P ��� ���I��
        }
        private void Update()
        {
            SpawnWeapon();
        }
        /// <summary>
        /// �ͦ��Z��
        /// 1.�p��ɶ�
        /// 2.�ɶ��ֿn�춡�j�ɶ�
        /// 3.�ͦ��Z��
        /// 4.���w�b�ͦ���m�W
        /// 5.�o�g�Z��
        /// 6.�ᤩ�Z�������O
        /// </summary>
        private void SpawnWeapon()
        {
            // Time.deltaTime �@�Ӽv�檺�ɶ�
            timer += Time.deltaTime;
            // print("�g�L���ɶ�:" + timer);

            // �p�G�p�ɾ� �j�󵥩� ���j�ɶ� �N�ͦ� �Z��
            if (timer >= dataWeapon.interval)
            {
                //print("�ͦ��Z��");
                // �H���� = �H��.�d��(�̤p�ȡA�̤j��) - ��Ƥ��]�t�̤j��
                int random = Random.Range(0, dataWeapon.v35pawnPoint.Length);
                //�y��
                Vector3 pos = transform.position + dataWeapon.v35pawnPoint[random];
                // Quaternion �|�줸 : �������׸�T����
                // Quaternion.Identity �s�ר�(0�A0�A0)
                // �Ȧs�Z�� = �ͦ�(����B�y�СB����)
                GameObject temp = Instantiate(dataWeapon.goWeapon, pos, Quaternion.identity);
                // �Ȧs�Z��.���o����<����>().�K�[���O( ��V * �t��)
                temp.GetComponent<Rigidbody2D>().AddForce(dataWeapon.v3Direction * dataWeapon.speed);
                timer = 0;
            }
        }
    }
}
