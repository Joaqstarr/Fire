using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanityManager : MonoBehaviour
{

    [SerializeField]
    private float[] waitTimesPerLevel;



    private float _sanityTimer;

    [SerializeField]
    private float[] _sanityTimes;

    [Serializable]
    struct VideoArray
    {
        public VideoBehavior[] _minigames;
    }

    [Serializable]
    class SpawnPoint
    {
        public Vector2 _position;
        public VideoBehavior _minigame;
    }

    [SerializeField]
    private SpawnPoint[] _spawnPoints;

    [SerializeField]
    VideoArray[] _minigames;

    public enum InsanityLevel
    {
        None,
        Low,
        Medium, 
        High,
        NUM
    }

    public static InsanityLevel _level;


    void Start()
    {
        _level = InsanityLevel.None;

        _sanityTimer = _sanityTimes[(int)_level];
        StartCoroutine(SpawnSanityMinigame());
    }

    private void Update()
    {
        _sanityTimer -= Time.deltaTime;
        if (_sanityTimer < 0 && !(_level >= InsanityLevel.High))
        {
            _level++;
            if ((int)_level < _sanityTimes.Length) {
                _sanityTimer = _sanityTimes[(int)_level];
            }

        }

    }

    IEnumerator SpawnSanityMinigame()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTimesPerLevel[(int)_level]);
            PlayRandomSanityMinigame();

        }
    }


    public void PlayRandomSanityMinigame()
    {

        int ranLevel = UnityEngine.Random.Range(0, (int)_level + 1);
        int ranMinigame = UnityEngine.Random.Range(0, _minigames[ranLevel]._minigames.Length);

        if (_minigames[ranLevel]._minigames.Length <= 0) return;

        VideoBehavior vidToSpawn = _minigames[ranLevel]._minigames[ranMinigame];
        
        VideoBehavior spawnedVid = Instantiate(vidToSpawn);

        SetPositionOfGameToSpawnPoint(spawnedVid);
    }

    private void SetPositionOfGameToSpawnPoint(VideoBehavior spawnedGame)
    {
        int ranStart = UnityEngine.Random.Range(0, _spawnPoints.Length);

        for(int i = 0; i < _spawnPoints.Length; i++)
        {
            int index = (ranStart+i) % _spawnPoints.Length;
            if (_spawnPoints[index]._minigame == null)
            {
                _spawnPoints[index]._minigame = spawnedGame;
                spawnedGame.transform.position = _spawnPoints[index]._position;

                return;
            }
        }

        Destroy(spawnedGame.gameObject);

    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            Gizmos.DrawWireSphere(_spawnPoints[i]._position, 0.1f);
        }

    }
}
