using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Utilities
{
    class DataSaver
    {
        public static void SaveTime()
        {
            string playerName = PlayerPrefs.GetString(Constant.PPK_PLAYER_NAME);
            string movementName = ((MovementGen.ChoiceOfMovement)PlayerPrefs.GetInt(Constant.PPK_MOVEMENT_CHOICE)).ToString();
            string time = PlayerPrefs.GetString(Constant.PPK_TIMER_TIME);
            string stage = PlayerPrefs.GetString(Constant.PPK_SCENE_NAME);
            string toSave = movementName + " - " + playerName + " - " + stage + " - "+ time;
            writeToFile(toSave);
        }

        public static void SavePosition(List<Position> position)
        {
            //TODO
        }

        private static async void writeToFile(string toSave)
        {
            using StreamWriter file = new(Constant.FILE_PATH + Constant.FILE_TIME);

            await file.WriteLineAsync(toSave);
        }

        private static async void writeToFile(List<float, float> toSave, string fileName)
        {
            using StreamWriter file = new(Constant.FILE_PATH + fileName);

            await file.WriteLineAsync(toSave);
        }
    }
}
