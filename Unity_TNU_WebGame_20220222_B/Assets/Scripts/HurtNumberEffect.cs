using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;  // �ޥ� �t��.���X(��Ƶ��c�B��P�{��)

namespace MengFan
{


    public class HurtNumberEffect : MonoBehaviour
    {
        private CanvasGroup group;
        private void Awake()
        {
            group = GetComponent<CanvasGroup>();

            StartCoroutine(Test());
        }

        // ��P�{��:����t�ε��ݡB����
        // 1. �ޥ� System.Collections
        // 2. �w�q��P�{�Ǥ�k�A�Ǧ^���� IEumerator
        // 3. �ϥ� yield return new WaitForSeconds(���ݬ��)
        // 4. �ϥαҰʨ�P�{�� StartCoroutine(��P�{�Ǥ�k)

        private IEnumerator Test()
        {
            print("�Ĥ@��");

            yield return new WaitForSeconds(2);

            print("����A�ĤG��");
        }
    }
}
