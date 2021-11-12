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
            //Nom du mouvement - Nom du joueur - Stage - Temps d'exécution
            string playerName = PlayerPrefs.GetString(Constant.PPK_PLAYER_NAME);
            string movementName = ((MovementGen.ChoiceOfMovement)PlayerPrefs.GetInt(Constant.PPK_MOVEMENT_CHOICE)).ToString();
            string time = PlayerPrefs.GetString(Constant.PPK_TIMER_TIME);
            string stage = ""; // TODO
            string toSave = movementName + " - " + playerName + " - " + stage + " - "+ time;
            writeToFile(toSave);
        }

        private static async void writeToFile(string toSave)
        {
            using StreamWriter file = new(Constant.FILE_TIME);

            await file.WriteLineAsync(toSave);
        }

        // TODO writeToFile(toSave, fileName) pour les positions
    }
}
