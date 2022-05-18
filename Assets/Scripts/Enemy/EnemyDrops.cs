using UnityEngine;

public class EnemyDrops : MonoBehaviour
{
    public Transform dropPosition;
    public GameObject[] dropTable;
    public float[] dropTableChances;

    void Start()
    {
        if (dropTable.Length != dropTableChances.Length)
        {
            Debug.Log("Incorrect setup of drop table and drop chances");
            return;
        }
    }

    public void RollDropTable()
    {
        int rand = Random.Range(0, 10001);
        float result = (rand * 1.0f) / 100.0f;

        float dropIntervalEnd = 0f;

        for (int i = 0; i < dropTable.Length; i++)
        {
            dropIntervalEnd += dropTableChances[i];
            
            if (dropIntervalEnd >= result)
            {
                Instantiate(dropTable[i], dropPosition.position, Quaternion.identity);
                break;
            }
        }
    }
}
