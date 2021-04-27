using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bombFactory;
    public Transform firePos;
    
    // ������ �Ŀ�
    public float throwPower = 15f;

    // �Ѿ�ȿ��
    public GameObject bulletEft;

    // �Ѿ� �Ŀ�
    public float bulletPower = 20f;

    void Update()
    {
        //// ���࿡ GameState�� Play�� �ƴҶ�
        //if (GameManager.instance.state != GameManager.GameState.Play)
        //{
        //    return; // ���⼭ �Լ� ������ if�� �ؿ� �ڵ� �������
        //}
        if (!GameManager.instance.isPlaying()) return;
        

        if (Input.GetButtonDown("Fire2"))
        {
            GameObject bomb = Instantiate(bombFactory);
            bomb.transform.position = firePos.position;
            
            // 4.��ź�� �ִ� rigidbody ��������.
            Rigidbody rb = bomb.GetComponent<Rigidbody>();
            // 5.ī�޶� �ٶ󺸴� �������� �������� ���� ���Ѵ�.
            rb.AddForce(Camera.main.transform.forward * throwPower);


        }

        // Fire1��ư (���콺����) ������
        if (Input.GetButtonDown("Fire1"))
        {
            // ī�޶��� �չ������� �߻�Ǵ� Ray�� �����.
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            // �������� �ε����� �� ������´�. �迭�� ������ �޴´�.
            RaycastHit[] hits =  Physics.RaycastAll(ray);
            if (hits.Length > 0)
            {
                for (int i = 0; i < hits.Length; i++)
                {
                    print(hits[i].transform.gameObject.name);
                }
            }

            // �ε��� ���� ������ ���� ����
            RaycastHit hit = new RaycastHit();

            int layerEnemy = 1 << LayerMask.NameToLayer("Enemy");
            int layerBomb = 1 << LayerMask.NameToLayer("Bomb");
            int layer = layerEnemy | layerBomb; // �̵ΰ��� �浹�ϰ� ����ڴ�.

            // �� Ray�� ��򰡿� �ε����� ������ ��Ƽ�
            if (Physics.Raycast(ray, out hit, 100, ~layer)) //layer���� ~���̸� �ΰ� ���� �� �浹
            {
                // �� ������ ���� ȿ���� ��������        
                //print(hit.transform.gameObject.name);
                // 1.�ε��� ��ġ�� ȿ���� ��ġ��Ű��
                bulletEft.transform.position = hit.point;
                // 2.�ε��� ��ġ�� normal(�����κ���)�� ������ ���
                bulletEft.transform.forward = hit.normal;
                // 3.��ƼŬ ����
                ParticleSystem ps = bulletEft.GetComponent<ParticleSystem>();
                ps.Play();
                
                // ���࿡ �������� Layer�� Enemy���
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    // Enemy ������Ʈ ��������
                    Enemy enemy = hit.transform.GetComponent<Enemy>();
                    // HitEnemy �Լ��� ����
                    enemy.HitEnemy(bulletPower);

                }
            }
            // 4.���� ����
            AudioSource audio = bulletEft.GetComponent<AudioSource>();
            audio.Play();
            
        }
    }
}
