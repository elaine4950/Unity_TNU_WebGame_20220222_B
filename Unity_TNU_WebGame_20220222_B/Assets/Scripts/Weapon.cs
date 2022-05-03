using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MengFan
{
    public class Weapon : MonoBehaviour
    {
        [HideInInspector]
        public float attack;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "�ĤH")
            {
                print("<color=red����ĤH:" + collision.gameObject + "</color>");
                collision.gameObject.GetComponent<HurtSystem>().GetHurt(attack);
            }
        }
    }
}