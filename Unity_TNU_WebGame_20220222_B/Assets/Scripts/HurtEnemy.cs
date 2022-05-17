using UnityEngine;

namespace MengFan
{
    /// <summary>
    /// �ĤH����:�u�X���˼Ʀr
    /// </summary>
    /// �l���O:�����O - �~�ӻy�k
    public class HurtEnemy : HurtSystem
    {
        [SerializeField, Header("�ĤH���")]
        private DataEnemy data;
        [SerializeField, Header("�e�����˼ƭ�")]
        private GameObject goCanvasHurt;
        [SerializeField, Header("�g��ȹD��")]
        private GameObject goExp;
        
        private string parameterDead = "Ĳ�o���`";
        private Animator ani;
        private EnemySystem enemySystem;

        
        private void Start()
        {
            ani = GetComponent<Animator>();
            enemySystem = GetComponent<EnemySystem>();

            hp = data.hp;
        }

        //override �мg : �мg���˧O�� vitrual ������
        //base ���������O�쥻���������e
        public override void GetHurt(float damage)
        {
            base.GetHurt(damage);
            
            GameObject temp = Instantiate(goCanvasHurt, transform.position, Quaternion.identity);
            temp.GetComponent<HurtNumberEffect>().UpdateHurtNumber(damage);
        }
            

        protected override void Dead()
        {
            base.Dead();

            ani.SetTrigger(parameterDead);
            enemySystem.enabled = false;
            GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject, 2);

            DropExp();

        }

        private void DropExp()
        {
            float random = Random.value;

            if (random <= data.expDropProbability)
            {
                GameObject tempExp = Instantiate(goExp, transform.position, Quaternion.identity);
                tempExp.AddComponent<Exp>().typeExp = data.typeExp;
            }
        }
    }

}
