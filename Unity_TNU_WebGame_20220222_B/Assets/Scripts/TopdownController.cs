using System.Collections;
using System.Collections.Generic;
using UnityEngine;  //�ޥ�Unity�R�W�Ŷ�

//�R�W�Ŷ� �Ŷ��W��
//�h�H�}�o�i�H�ϥΩR�W�Ŷ��Ϲj�t���קK�Ĭ�
namespace Cangshu
{
    //���} ���O �}���W�� (�P���W���ɮצW�٬ۦP�A�j�p�g�@�ˡA����ϥΪŮ�P�S��r��#@!?)
    public class TopdownController : MonoBehaviour
    {
        #region ���:�O�s�t�λݭn���򥻸�ơA�Ҧp:���ʳt�סB�ʵe�ѼƦW�ٻP���󵥵�
        //��� field �y�k:�׹��� ������� ���W�� (���w ��l��);
        //private �p�H�A�Ppublic�ۤ�:���\��L�t�Φs��
        private float speed = 10.5f;
        private string parameteRun = "�}���]�B";
        private string parameterDead = "�}�����`";
        private Animator ani;
        private Rigidbody2D rig;
        #endregion

        #region �ƥ�:�{���H�f(Unity)�D���Ѷ}�o���X�ʨt�Ϊ����f
        //����ƥ�:����C�������@���A�B�z��l�ơA���o��ơA��ƪ�l��
        private void Awake()
        {
            //��X(�T��)�A�N�T����X��Unity Console(�����O)Ctrl+Shift+c
            print("�ڬO����ƥ�~");

            //��� ���w�� ���o����<����W��>()
            // <�x��> �x��:����������
            ani = GetComponent<Animator>();
            rig = GetComponent<Rigidbody2D>();
        }
        //��s�ƥ�:����C����H�C���60������A60FPS (Frame Per Second)
        //�B�z:����ʦ欰 - ���ʡB����B�Y��A���a��J - �ƹ��B��L�BĲ���B�n��
        private void Update()
        {
            print("�ڦb Update �ƥ�~");
        }
        #endregion

        #region ��k:���������\��(���z���B�t��k�ε{���϶�)
        #endregion
    }
}
