using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

namespace CollisionSample
{
    public class PlayerController : MonoBehaviour
    {
        NavMeshAgent agent;
        Material myMat;

        public Slider hpGauge;
        public int MaxHp = 100;
        int hp = 0;

        public Damage damage;
        public Heal heal;
        public Transform damageRoot;
        public float damageDuration;
        public float healDuration;
        float elapsedTimeFromDamage;
        float elapsedTimeForHeal;

        bool isDamage;
        bool isHeal;

        private StatusSimulator simulator;

        public Transform projecttileRoot;

        public Projectile projectile;

        Animator anim;

        public AttackObject attackObject;

        public Magic magic;

        void Start()
        {
            hp = MaxHp;
            hpGauge.minValue = 0;
            hpGauge.maxValue = MaxHp;
            hpGauge.value = hp;

            agent = GetComponent<NavMeshAgent>();
            myMat = GetComponent<MeshRenderer>().material;
            simulator = GetComponent<StatusSimulator>();
            anim = GetComponent<Animator>();
        }

        void Update()
        {

            Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            Vector2 inputSwitch = new Vector2(Input.GetAxis("Horizontal1"), Input.GetAxis("Vertical1"));
            input += inputSwitch;

            if (input.magnitude > 0f) 
            {
                Vector3 dest = transform.position;
                dest += Vector3.forward * input.y;// * agent.speed;
                dest += Vector3.right * input.x;// * agent.speed;
                agent.destination = dest;
            }

            if (Input.GetKeyDown(KeyCode.Space) ||
                Input.GetKeyDown(KeyCode.Joystick1Button15))
            {
                Shoot();
            }

            if (Input.GetKeyDown(KeyCode.LeftShift) ||
                Input.GetKeyDown(KeyCode.Joystick1Button14))
            {
                var dashDest = transform.forward * 5;
                agent.Move(dashDest);
                agent.destination = dashDest; 
            }

            if (Input.GetKeyDown(KeyCode.E) ||
                Input.GetKeyDown(KeyCode.Joystick2Button15))
            {
                anim.SetTrigger("Attack");
                var atkObj = Instantiate(attackObject.gameObject);
                
                var forwardPos = transform.forward * 1.5f;
                var pos = transform.position;

                atkObj.transform.position = new Vector3(forwardPos.x + pos.x,transform.position.y,forwardPos.z + pos.z);
                atkObj.transform.eulerAngles = transform.eulerAngles;
            }

            if (Input.GetKeyDown(KeyCode.Q) ||
                Input.GetKeyDown(KeyCode.Joystick2Button14))
            {
                var magicObj = Instantiate(magic.gameObject);
                var forwardPos = transform.forward * 2f;;
                var pos = transform.position;

                magicObj.transform.position=new Vector3(forwardPos.x + pos.x,transform.position.y,forwardPos.z + pos.z);;
                magicObj.transform.eulerAngles = transform.eulerAngles;
            }

            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    var magicPos = hit.point;
                    var magicObj = Instantiate(magic.gameObject);
                    magicObj.transform.position=magicPos;
                }
            }

            if (isDamage)
            {
                elapsedTimeFromDamage += Time.deltaTime;
                if (elapsedTimeFromDamage >= damageDuration)
                {
                    simulator.EndSimulate();
                    elapsedTimeFromDamage = 0f;
                    isDamage = false;
                }
            }

            if (isHeal)
            {
                elapsedTimeForHeal += Time.deltaTime;
                if (elapsedTimeForHeal >= healDuration)
                {
                    simulator.EndSimulate();
                    elapsedTimeForHeal = 0f;
                    isHeal = false;
                }
            }
        }

        void Shoot()
        {
            var spawnPos = projecttileRoot.position;
            var targetDirection = transform.eulerAngles;
            Projectile p = Instantiate(projectile).GetComponent<Projectile>();
            p.transform.position = spawnPos;
            p.transform.eulerAngles = targetDirection;
        }
        
        void EndDamage()
        {
            myMat.SetColor("_BaseColor", Color.white);
            elapsedTimeFromDamage = 0f;
            isDamage = false;
        }

        void OnDamge()
        {
            int hitDamage = Random.RandomRange(1, 15);
            hp -= hitDamage;
            hp = (int)Mathf.Max(0,hp);

            Damage damageDisp = Instantiate(damage.gameObject, damageRoot).GetComponent<Damage>();
            damageDisp.transform.localPosition = new Vector3(Random.Range(-4, 4), Random.Range(0, 4), 0f);
            damageDisp.Setup(hitDamage, Random.Range(1f, 3f));
            hpGauge.value = hp;

            simulator.Simulate(StatusSimulator.Type.Damage);
            isDamage = true;
        }

        void OnHeal()
        {
            int recoverHp = Random.RandomRange(10, 25);
            hp += recoverHp;

            Heal healDisp = Instantiate(heal.gameObject, damageRoot).GetComponent<Heal>();
            healDisp.transform.localPosition = new Vector3(Random.Range(-4, 4), Random.Range(0, 4), 0f);
            healDisp.Setup(recoverHp, Random.Range(1f, 3f));
            hpGauge.value = hp;

            simulator.Simulate(StatusSimulator.Type.Healing);
            isHeal = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            //myMat.SetColor("_Color", Color.red);

            if (other.CompareTag("Damage"))
            {
                if (!isDamage) OnDamge();
            }
            else if (other.CompareTag("Healing"))
            {
                if (!isHeal) OnHeal();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Damage"))
            {
                if (!isDamage) OnDamge();
            }
            else if (other.CompareTag("Healing"))
            {
                if (!isHeal) OnHeal();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            
        }
    }

}