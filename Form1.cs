using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ELO_Rating
{
    public partial class Form1 : Form
    {
        SQLiteConnection dbConnection = new SQLiteConnection("Data Source=playerInfo.sqlite;Version=3;");

        public Form1()
        {
            if (!File.Exists("playerInfo.sqlite")) SQLiteConnection.CreateFile("playerInfo.sqlite");
            dbConnection.Open();
            SQLiteCommand checkTables = new SQLiteCommand("Select Count(*) as nTables FROM sqlite_master where type='table';", dbConnection);
            var result = checkTables.ExecuteScalar();
            if (Convert.ToInt32(result) == 0)
            {
                SQLiteCommand addTable = new SQLiteCommand(
                    "CREATE TABLE playerInfo(" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "name VARCHAR(50), " + 
                    "rating INT, " +
                    "wins INT, " + 
                    "losses INT, " + 
                    "draws INT" + 
                    ");",
                    dbConnection
                    );
                addTable.ExecuteNonQuery();
                addTable = new SQLiteCommand(
                    "CREATE TABLE gameInfo(" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT, " + 
                    "whitescore REAL, " + 
                    "blackscore REAL, " + 
                    "whitename VARCHAR(50), " + 
                    "blackname VARCHAR(50), " + 
                    "date VARCHAR(15)" + 
                    ");", 
                    dbConnection
                    );
                addTable.ExecuteNonQuery();
            }
            InitializeComponent();
        }

        private void addNewPlayer(string playerName)
        {
            SQLiteCommand playerAdd = new SQLiteCommand(
                "INSERT INTO playerInfo(name, rating, wins, losses, draws) VALUES (\'" + 
                playerName + "\', 1000, 0, 0, 0)",
                dbConnection
                );
            playerAdd.ExecuteNonQuery();
        }

        private void AddGameButton_Click(object sender, EventArgs e)
        {
            var gf = new AddGameForm();
            if (gf.ShowDialog() == DialogResult.OK)
            {
                string whiteName = gf.whiteName;
                string blackName = gf.blackName;
                double whiteScore = gf.whiteScore;
                double blackScore = 1 - whiteScore;

                int whiteELO = 1000, blackELO = 1000;
                SQLiteCommand getPlayer = new SQLiteCommand("SELECT * FROM playerInfo WHERE name=\'" + whiteName + "\';", dbConnection);
                SQLiteDataReader reader = getPlayer.ExecuteReader();
                bool updateRanks = true;
                int numResults = 0;
                while (reader.Read())
                {
                    numResults++;
                    whiteELO = (int)(reader["rating"]);
                }
                if (numResults == 0)
                {
                    DialogResult createNew = MessageBox.Show("Did not find player named \'" + whiteName + "\'. Create new player?", "Player not found", MessageBoxButtons.YesNo);
                    if (createNew == DialogResult.Yes)
                    {
                        addNewPlayer(whiteName);
                    }
                    else updateRanks = false;
                }
                getPlayer = new SQLiteCommand("SELECT * FROM playerInfo WHERE name=\"" + blackName + "\";", dbConnection);
                reader = getPlayer.ExecuteReader();
                numResults = 0;
                while (reader.Read())
                {
                    numResults++;
                    blackELO = (int)(reader["rating"]);
                }
                if (numResults == 0)
                {
                    DialogResult createNew = MessageBox.Show("Did not find player named \"" + blackName + "\". Create new player?", "Player not found", MessageBoxButtons.YesNo);
                    if (createNew == DialogResult.Yes)
                    {
                        addNewPlayer(blackName);
                    }
                    else updateRanks = false;
                }
                if (updateRanks)
                {
                    SQLiteCommand addGame = new SQLiteCommand(
                        "INSERT INTO gameInfo(whitescore, blackscore, whitename, blackname, date) VALUES(" +
                        whiteScore + ", " +
                        blackScore + ", \'" +
                        whiteName + "\', \'" +
                        blackName + "\', \'" +
                        DateTime.Today.ToString("d") + "\')",
                        dbConnection
                        );
                    addGame.ExecuteNonQuery();

                    int[] newRatings = getNewRatings(new int[] { whiteELO, blackELO }, whiteScore);
                    string[] updateVals = new string[] { "wins", "losses" };
                    if (whiteScore == 0) updateVals = new string[] { "losses", "wins" };
                    else if (whiteScore == .5) updateVals = new string[] { "draws", "draws" };
                    SQLiteCommand updateELO = new SQLiteCommand("UPDATE playerInfo SET rating=" + newRatings[0] + ", " + updateVals[0] + "=" + updateVals[0] + " + 1 WHERE name=\'" + whiteName + "\';", dbConnection);
                    updateELO.ExecuteNonQuery();
                    updateELO = new SQLiteCommand("UPDATE playerInfo SET rating=" + newRatings[1] + ", " + updateVals[1] + "=" + updateVals[1] + " + 1 WHERE name=\'" + blackName + "\';", dbConnection);
                    updateELO.ExecuteNonQuery();
                    MessageBox.Show("Scores updated!\nNew score for " + whiteName + ": " + newRatings[0] + "\nNew score for " + blackName + ": " + newRatings[1]);
                }
            }
            else return;
        }

        //pre: playerScores is an int[] containing the current ELO ratings of both players
        //playerScores[0] is considered the winner unless p1score is set
        private int[] getNewRatings(int[] playerRatings, double p1score)
        {
            int[] retVal = new int[2];

            int p1variation = 24, p2variation = 24;
            //base K values on current rating
            if (playerRatings[0] >= 1600) p1variation = 18;
            else if (playerRatings[0] <= 1250) p1variation = 32;
            if (playerRatings[1] >= 1600) p2variation = 18;
            else if (playerRatings[1] <= 1250) p2variation = 32;

            double expectedWinOne = 1/(Math.Pow(10, (playerRatings[1] - playerRatings[0]) / 300.0) + 1);
            double expectedWinTwo = 1 - expectedWinOne;

            double eloChange1 = p1variation * (p1score - expectedWinOne);
            double eloChange2 = p2variation * ((1 - p1score) - expectedWinTwo);

            retVal[0] = (int)(playerRatings[0] + eloChange1);
            retVal[1] = (int)(playerRatings[1] + eloChange2);

            return retVal;
        }

        private void GenListButton_Click(object sender, EventArgs e)
        {
            SQLiteCommand getScores = new SQLiteCommand("SELECT * FROM playerInfo ORDER BY rating DESC;", dbConnection);
            using (StreamWriter file = new StreamWriter(@"scores.txt"))
            {
                file.WriteLine("Name\t\t\tRating\t\tWins\t\tLosses\t\tDraws");
                SQLiteDataReader reader = getScores.ExecuteReader();
                while (reader.Read())
                {
                    string postNameBuf = new string('\t', 3 - (int)(((string)(reader["name"])).Length/8));
                    file.WriteLine(reader["name"] + postNameBuf + reader["rating"] + "\t\t" + reader["wins"] + "\t\t" + reader["losses"] + "\t\t" + reader["draws"]);
                }
            }
            MessageBox.Show("Successfully wrote to: " + Directory.GetCurrentDirectory() + "\\scores.txt");
        }
    }
}
