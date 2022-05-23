using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System;

namespace Assets.Scripts.GroundComponents
{
    public class GroundSpawner
    {
        private readonly GameObject _groundBlock;

        private int _delayBetweenSpawn;
        private float _minScale, _maxScale;

        private Vector2 _spawnPosition = new(5, -4f);


        public GroundSpawner(GameObject groundBlock)
        {
            this._groundBlock = groundBlock;
            InitSpawnParameters();

            _ = SpawnGroundAsync();
        }

        private async Task SpawnGroundAsync()
        {
            while(Application.IsPlaying(_groundBlock))
            {
                await Task.Delay(_delayBetweenSpawn);

                if (!Application.isPlaying) return;

                float randomSize = UnityEngine.Random.Range(_minScale, _maxScale);

                var block = GetGroundBlock();
                block.transform.localScale = new Vector2(randomSize, block.transform.localScale.y);
            }
        }

        private void InitSpawnParameters()
        {
            var spawnParameters = File.ReadAllText(Path.Combine(Application.streamingAssetsPath, "SpawnParameters.json"));
            var parameters = JsonConvert.DeserializeObject<Dictionary<string, object>>(spawnParameters);

            _delayBetweenSpawn = Convert.ToInt32(parameters["Delay"]);
            _minScale = (float)Convert.ToDouble(parameters["MinScale"]);
            _maxScale = (float)Convert.ToDouble(parameters["MaxScale"]);
        }

        private GameObject GetGroundBlock()
        {
            var block = GameObject.Instantiate(_groundBlock, _spawnPosition, Quaternion.identity);
            return block;
        }
    }
}
