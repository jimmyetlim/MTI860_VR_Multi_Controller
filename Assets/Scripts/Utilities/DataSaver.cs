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
            string toSave = movementName + Constant.SEPARATOR + playerName + Constant.SEPARATOR + stage + Constant.SEPARATOR + time;
            writeToFile(toSave);
        }

        public static void SavePosition(List<Position> positions)
        {
            string playerName = PlayerPrefs.GetString(Constant.PPK_PLAYER_NAME);
            string movementName = ((MovementGen.ChoiceOfMovement)PlayerPrefs.GetInt(Constant.PPK_MOVEMENT_CHOICE)).ToString();
            string stage = PlayerPrefs.GetString(Constant.PPK_SCENE_NAME);
            string fileName = movementName + Constant.SEPARATOR + playerName + Constant.SEPARATOR + stage;
            writeToFile(positions, fileName);
        }

        private static async void writeToFile(string toSave)
        {
            using StreamWriter file = File.AppendText(Constant.FILE_PATH + Constant.FILE_TIME + Constant.FILE_EXTENSION);
            await file.WriteLineAsync(toSave);
        }

        private static async void writeToFile(List<Position> positions, string fileName)
        {
            using StreamWriter file = File.AppendText(Constant.FILE_PATH + fileName + Constant.FILE_EXTENSION);

            foreach (Position pos in positions)
            {
                await file.WriteLineAsync(pos.ToString());
            }
        }
    }
}
