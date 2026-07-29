using System.Collections;
using TMPro;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] wallz;
    Transform finalPos;
    [SerializeField] int amountOfWalls = 10;
    int currentWalls = 0;
    [SerializeField] float destroyTimeOffSet = 0;
    [SerializeField] int countDownNum = 3;
    [SerializeField] TextMeshProUGUI countDownTxt;

    private void OnEnable()
    {
        finalPos = GameObject.Find("EndPosition").transform;
    }

    IEnumerator SpawnWalls()
    {
        int randomNum = Random.Range(0, wallz.Length);
        Debug.Log(randomNum);
        GameObject wall = Instantiate(wallz[randomNum], transform.position, wallz[randomNum].transform.rotation);
        yield return SpawnTime(wall);
        currentWalls++;
        if (currentWalls >= amountOfWalls)
        {
            countDownTxt.text = "GAME OVER";
            yield break;
        }
        else
            StartCoroutine(SpawnWalls());
    }
    IEnumerator SpawnTime(GameObject obj)
    {
        if(obj.TryGetComponent<MovingWall>(out MovingWall wall))
        {
            wall.finalPos = finalPos;
            yield return new WaitForSeconds(wall.GetDurationTime() + destroyTimeOffSet);
            Destroy(obj);
        }
        else yield return null;
    }
    IEnumerator CountDown()
    {
        if (countDownTxt == null) yield return null;
        else
        {
            countDownTxt.text = $"{countDownNum}";
            countDownNum--;
            yield return new WaitForSeconds(1.5f);
            if (countDownNum >= 0)
                StartCoroutine(CountDown());
            else
                StartCoroutine(SpawnWalls());
        }
    }

    public void EnableWave()
    {
        GameManger.ApplyToUpdate -= EnableWave;
        StartCoroutine(CountDown());
    }
}
