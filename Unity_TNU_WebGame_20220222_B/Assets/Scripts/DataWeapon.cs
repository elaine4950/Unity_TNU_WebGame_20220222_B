using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MengFan
{
    /// <summary>
    /// �Z�����
    /// 1.����t��
    /// 2.�����O
    /// 3.�_�l�ƶq
    /// 4.�̤j�ƶq
    /// 5.���j�ɶ�
    /// 6.�ͦ���m
    /// 7.�Z���w�s��
    /// 8.�����V
    /// </summary>
    // ScriptableObject �}���ƪ���
    // �@��:�N�}��������ܦ������x�s��Project��(�X�R�P���@�ʨ�)
    // CreateAssetMenu �P ScriptableObject �f�t�ϥ�
    // �@��:�bProject �إߦ��}���ƪ��󪺿��P�ɮצW��
    // meauName ���W�١BfileName �ɮצW��
    [CreateAssetMenu(menuName = "MengFan/Data Weapon", fileName = "Data Weapon")]
    public class DataWeapon : ScriptableObject
    {
        [Header("����t��"), Range(0, 5000)]
        public float speed = 500;
        [Header("�����O"), Range(0, 100)]
        public float attack = 10;
        [Header("�_�l�ƶq"), Range(1, 10)]
        public int countStart = 1;
        [Header("�̤j�ƶq"), Range(1, 20)]
        public int countMax = 3;
        [Header("���j�ɶ�"), Range(0, 5)]
        public float interval = 3.5f;

        //�������[] �}�C - ��Ƶ��c
        //�@�� : �x�s�h���ۦP���������
        [Header("�ͦ���m")]
        public Vector3[] v35pawnPoint;
        [Header("�Z���w�s��")]
        public GameObject goWeapon;
        [Header("�����V")]
        public Vector3 v3Direction;
    }
}
