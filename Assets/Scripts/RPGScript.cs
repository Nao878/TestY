using System.Collections;
using UnityEngine;

public class RPGScript : MonoBehaviour
{
    public int playerHP = 20;
    public int playerATK = 5;
    public int enemyHP = 15;
    public int enemyATK = 4;
    public bool isPlayerTurn = true;
    public bool isBattleEnd = false;

    void Start()
    {
        Debug.Log("�o�g���J�n�I �X�y�[�X�L�[�ōU��");
        ShowStatus();
    }

    void Update()
    {
        if (isBattleEnd) return;

        if (isPlayerTurn)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // �v���C���[�̍U��
                enemyHP -= playerATK;
                Debug.Log($"�v���C���[�̍U���I �G��{playerATK}�_���[�W");
                if (enemyHP <= 0)
                {
                    enemyHP = 0;
                    Debug.Log("�G��|�����I �����I");
                    isBattleEnd = true;
                    ShowStatus();
                    return;
                }
                ShowStatus();
                isPlayerTurn = false;
                StartCoroutine(EnemyTurn());
            }
        }
    }

    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(1.0f);
        playerHP -= enemyATK;
        Debug.Log($"�G�̍U���I �v���C���[��{enemyATK}�_���[�W");
        if (playerHP <= 0)
        {
            playerHP = 0;
            Debug.Log("�v���C���[�͓|�ꂽ�c �s�k");
            isBattleEnd = true;
            ShowStatus();
            yield break;
        }
        ShowStatus();
        isPlayerTurn = true;
    }

    void ShowStatus()
    {
        Debug.Log($"�v���C���[HP: {playerHP} / �GHP: {enemyHP}");
    }
}
