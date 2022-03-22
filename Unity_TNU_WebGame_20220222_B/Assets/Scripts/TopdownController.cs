using System.Collections;
using System.Collections.Generic;
using UnityEngine;  // �ޥ�UnityEngine �R�W�Ŷ�

// �R�W�Ŷ� �Ŷ��W��
// �h�H�}�o�i�H�ϥΩR�W�Ŷ��Ϲj�t���קK�Ĭ�
namespace MengFan
{
    // ���} ���O �}���W�� (�P���W���ɮצW�٬ۦP�A�j�p�g�@�ˡA����ϥΪŮ�P�S��r��#@!?)
    // summary �K�n�A�i�H�b���O�B��ơB�ƥ�P��k�W��K�[�T���u ///
    // ²�u����
    /// <summary>
    /// ���ⱱ�:Top Down ����
    /// </summary>
    public class TopdownController : MonoBehaviour
    {
        #region ���:�O�s�t�λݭn���򥻸�ơA�Ҧp:���ʳt�סB�ʵe�ѼƦW�ٻP���󵥵�
        // ��� field �y�k:
        // �׹��� ������� ���W�� (���w ��l��);
        // private �p�H�A�Ppublic�ۤ�:���\��L�t�Φs��

        // [] Attribute �ݩ� : ���U���O�B��ơB�ƥ�P��k
        // SertializeField �ǦC�e��� : ���p�H�����ܦb�ݩʭ��O�W
        // Header("���D") ���D
        // Ranger(�̤p�ȡA�̤j��) �d�򭭨�
        [SerializeField, Header("���ʳt��"), Range(0,100)]
        private float speed = 10.5f;
        private string parameteRun = "�}���]�B";
        private string parameterDead = "�}�����`";
        private Animator ani;
        private Rigidbody2D rig;
        private float h;
        private float v;
        #endregion

        #region �ƥ�:�{���H�f(Unity)�D���Ѷ}�o���X�ʨt�Ϊ����f
        //����ƥ�:����C�������@���A�B�z��l�ơA���o��ơA��ƪ�l��
        private void Awake()
        {
            //��X(�T��)�A�N�T����X��Unity Console(�����O)Ctrl+Shift+c
           // print("�ڬO����ƥ�~");

            //��� ���w�� ���o����<����W��>()
            // <�x��> �x��:����������
            ani = GetComponent<Animator>();
            rig = GetComponent<Rigidbody2D>();
        }
        //��s�ƥ�:����C����H�C���60������A60FPS (Frame Per Second)
        //�B�z:����ʦ欰 - ���ʡB����B�Y��A���a��J - �ƹ��B��L�BĲ���B�n��
        private void Update()
        {
            //print("�ڦb Update �ƥ�~");
            GetInput();
            Move();
        }
        #endregion

        #region ��k:���������\��(���z���B�t��k�ε{���϶�)
        
        // ��k method �y�k :
        // �׹��� �Ǧ^������� ��k�W�� (�Ѽ�) { �{���϶� }
        // void �L�Ǧ^

        /// <summary>
        /// ���o���a��J���
        /// ���kAD Horizontal
        /// �W�UWS Vertical
        /// </summary>
        private void GetInput()
        {
            // �ϥ��R�A��k�y�k static
            // ���O�W��.�R�A��k�W��(�����޼�);
            // float h = *****; - �ϰ��ܼ� : �ȯ�b�ӵ��c(�j�A����) �s��
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
            // ��X�T��(�T��) - Ctrl + Shift + C �����O (Console)
            // print("���o�����b����:" + h); 
        }

        /// <summary>
        /// ����
        /// </summary>
        private void Move()
        {
            // �ϥΫD�R�A�ݩ� non-static
            // ���W��.�R�A�ݩʦW�� ���w ��
            // ����.�[�t�� = �s �G���V�q(�����A����) * �t��
            rig.velocity = new Vector2(h, v) * speed;
            // �ʵe���.�]�w���L��(�ѼƦW�١A���L��)
            // ���� ������ �s �Ϊ� ���� ������ �s
            ani.SetBool(parameteRun, h != 0 || v != 0);

            // �T���B��l�y�k
            // ���L�� ? ���L�� ���� True ; ���L�� ���� false
            //  ���� >= 0 ���� 0 �_�h ���� 180
            // �ܧΤ��� ,�کԨ� = �s �T��V�q(X�BY�BZ)
            transform.eulerAngles = new Vector3(0, h >= 0 ? 0 : 180, 0);
            
        }
        #endregion
    }
}
