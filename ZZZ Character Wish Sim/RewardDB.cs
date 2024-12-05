using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace ZZZ_Character_Wish_Sim
{
    internal class RewardDB
    {
        public RewardDB() { }

        private string createWeaponsTableQuery = @"
                        CREATE TABLE IF NOT EXISTS WeaponRewards
                            (id INTEGER PRIMARY KEY AUTOINCREMENT,
                            reward_name TEXT NOT NULL,
                            reward_tier INTEGER NOT NULL,
                            weapon_combat_type TEXT NOT NULL,
                            reward_image_path TEXT);
                        ";

        private string createCharactersTableQuery = @"
                        CREATE TABLE IF NOT EXISTS CharacterRewards
                            (id INTEGER PRIMARY KEY AUTOINCREMENT,
                            reward_name TEXT NOT NULL,
                            reward_tier INTEGER NOT NULL,
                            character_combat_type TEXT NOT NULL,
                            character_element TEXT NOT NULL,
                            reward_image_path TEXT);
                        ";


        private string insertWeaponsQuery = @"
                    INSERT INTO WeaponRewards (reward_name, reward_tier, weapon_combat_type, reward_image_path) 
                        VALUES (@reward_name, @reward_tier, @weapon_combat_type, @reward_image_path);";




        private string insertCharactersQuery = @"
                    INSERT INTO CharacterRewards (reward_name, reward_tier, character_combat_type, character_element, reward_image_path) 
                        VALUES (@reward_name, @reward_tier, @character_combat_type, @character_element, @reward_image_path);";



        // ============================================================================================ //
        // ============================================================================================ //
        // CREATE DBs
        // ============================================================================================ //
        // ============================================================================================ //


        public void createDB()
        {

            string databasePath = "Data Source=zenless_rewards.db";

            using (SqliteConnection connection = new SqliteConnection(databasePath))
            {

                connection.Open();


                SqliteCommand createWeaponsTable = new SqliteCommand(createWeaponsTableQuery, connection);
                SqliteCommand createCharactersTable = new SqliteCommand(createCharactersTableQuery, connection);

                SqliteCommand insertIntoWeaponsTable = new SqliteCommand(insertWeaponsQuery, connection);
                SqliteCommand insertIntoCharactersTable = new SqliteCommand(insertCharactersQuery, connection);


                var charRewards = new (string characterName, int rewardTier, string combatType, string element, string imagePath)[]
                {
                    ("Anby", 4, "Stun", "Electric", " "),
                    ("Piper", 4, "Attack", "Physical", " "),
                    ("Billy", 4, "Attack", "Physical", " "),
                    ("Ben", 4, "Defense", "Fire", " "),
                    ("Corin", 4, "Attack", "Physical", " "),
                    ("Anton", 4, "Attack", "Physical", " "),
                    ("Seth", 4, "Defense", "Electric", " "),
                    ("Soukaku", 4, "Support", "Ice", " "),
                    ("Lucy", 4, "Support", "Fire", " "),
                    ("Nicole", 4, "Support", "Ether", " "),
                    ("Caesar", 5, "Defense", "Physical", " "),
                    ("Yanagi", 5, "Anomaly", "Electric", " "),
                    ("Burnice", 5, "Anomaly", "Fire", " "),
                    ("Zhu Yuan", 5, "Attack", "Ether", " "),
                    ("Jane Doe", 5, "Attack", "Physical", " "),
                    ("Ellen Joe", 5, "Attack", "Ice", " "),
                    ("Qingyi", 5, "Stun", "Electric", " "),
                    ("Lighter", 5, "Stun", " Fire", " "),
                    ("Lyacon", 5, "Stun", "Ice", " "),
                    ("Grace", 5, "Anomaly", "Electric", " "),
                    ("Soldier 11", 5, "Attack", "Fire", " "),
                    ("Koleda", 5, "Stun", "Fire", " "),
                    ("Rina", 5, "Support", "Electric", " "),
                    ("Nekomata", 5, "Attack", "Physical", " ")
                };

                var weaponRewards = new (string weaponName, int rewardTier, string combatType, string imagePath)[]
                {


                    ("Blazing Laurel", 5, "Stun", ""),
                    ("Deep Sea Visitor", 5, "Attack", ""),
                    ("Flamemaker Shaker", 5, "Anomaly", ""),
                    ("Fusion Compiler", 5, "Anomaly", ""),
                    ("Hellfire Gears", 5, "Stun", ""),
                    ("Ice-Jade Teapot", 5, "Stun", ""),
                    ("Riot Suppressor Mark VI", 5, "Attack", ""),
                    ("Sharpened Stinger", 5, "Anomaly", ""),
                    ("Steel Cushion", 5, "Attack", ""),
                    ("The Brimstone", 5, "Attack", ""),
                    ("The Restrained", 5, "Stun", ""),
                    ("Timeweaver", 5, "Anomaly", ""),
                    ("Tusks of Fury", 5, "Defense", ""),
                    ("Weeping Cradle", 5, "Support", ""),
                    ("Bashful Demon", 4, "Support", ""),
                    ("Big Cylinder", 4, "Defense", ""),
                    ("Bunny Band", 4, "Defense", ""),
                    ("Demara Battery Mark II", 4, "Stun", ""),
                    ("Drill Rig - Red Axis", 4, "Attack", ""),
                    ("Weeping Gemini", 4, "Anomaly", ""),
                    ("Gilded Blossom", 4, "Attack", ""),
                    ("Housekeeper", 4, "Attack", ""),
                    ("Kaboom the Cannon", 4, "Support", ""),
                    ("Original Transmorpher", 4, "Defense", ""),
                    ("Peacekeeper Specialized", 4, "Defense", ""),
                    ("Precious Fossilized Core", 4, "Stun", ""),
                    ("Rainforest Gourmet", 4, "Anomaly", ""),
                    ("Roaring Ride", 4, "Anomaly", ""),
                    ("Slice of Time", 4, "Support", ""),
                    ("Starlight Engine", 4, "Attack", ""),
                    ("Starlight Engine Replica", 4, "Attack", ""),
                    ("Steam Oven", 4, "Stun", ""),
                    ("Street Superstar", 4, "Attack", ""),
                    ("The Vault", 4, "Support", ""),
                    ("Identify - Base", 3, "Defense", ""),
                    ("Identify - Inflection", 3, "Defense", ""),
                    ("Lunar - Decrescent", 3, "Attack", ""),
                    ("Lunar - Noviluna", 3, "Attack", ""),
                    ("Lunar - Pleniluna", 3, "Attack", ""),
                    ("Magnetic Storm - Alpha", 3, "Anomaly", ""),
                    ("Magnetic Storm - Bravo", 3, "Anomaly", ""),
                    ("Magnetic Storm - Charlie", 3, "Anomaly", ""),
                    ("Reverb - Mark I", 3, "Support", ""),
                    ("Reverb - Mark II", 3, "Support", ""),
                    ("Reverb - Mark III", 3, "Support", ""),
                    ("Vortex - Arrow", 3, "Stun", ""),
                    ("Vortex - Hatchet", 3, "Stun", ""),
                    ("Vortex - Revolver", 3, "Stun", "")

                };


                createWeaponsTable.ExecuteNonQuery();
                createCharactersTable.ExecuteNonQuery();

                foreach (var reward in charRewards)
                {
                    insertIntoCharactersTable.Parameters.Clear();
                    insertIntoCharactersTable.Parameters.AddWithValue("@reward_name", reward.characterName);
                    insertIntoCharactersTable.Parameters.AddWithValue("@reward_tier", reward.rewardTier);
                    insertIntoCharactersTable.Parameters.AddWithValue("@character_combat_type", reward.combatType);
                    insertIntoCharactersTable.Parameters.AddWithValue("@character_element", reward.element);
                    insertIntoCharactersTable.Parameters.AddWithValue("@reward_image_path", reward.imagePath);
                    insertIntoCharactersTable.ExecuteNonQuery();

                }


                foreach (var reward in weaponRewards)
                {

                    insertIntoWeaponsTable.Parameters.Clear();
                    insertIntoWeaponsTable.Parameters.AddWithValue("@reward_name", reward.weaponName);
                    insertIntoWeaponsTable.Parameters.AddWithValue("@reward_tier", reward.rewardTier);
                    insertIntoWeaponsTable.Parameters.AddWithValue("@weapon_combat_type", reward.combatType);
                    insertIntoWeaponsTable.Parameters.AddWithValue("@reward_image_path", reward.imagePath);
                    insertIntoWeaponsTable.ExecuteNonQuery();

                }

                connection.Close();

            }

        }

        // ============================================================================================ //
        // ============================================================================================ //
        // WEAPON ROLLS
        // ============================================================================================ //
        // ============================================================================================ //



        public string GetRandom3Star()
        {

            string query = "SELECT reward_name FROM WeaponRewards WHERE reward_tier = 3 ORDER BY RANDOM() LIMIT 1;";

            string databasePath = "Data Source=zenless_rewards.db";

            using (SqliteConnection connection = new SqliteConnection(databasePath))
            {

                connection.Open();

                SqliteCommand get3Stars = new SqliteCommand(query, connection);

                string random3Star = (string)get3Stars.ExecuteScalar();


                connection.Close();

                return random3Star;

            }

        }

        public string GetRandom4StarWeapon()
        {

            string query = "SELECT reward_name FROM WeaponRewards WHERE reward_tier = 4 ORDER BY RANDOM() LIMIT 1;";

            string databasePath = "Data Source=zenless_rewards.db";

            using (SqliteConnection connection = new SqliteConnection(databasePath))
            {

                connection.Open();

                SqliteCommand get4StarWeapons = new SqliteCommand(query, connection);

                string random4StarWeapon = (string)get4StarWeapons.ExecuteScalar();


                connection.Close();

                return random4StarWeapon;

            }

        }

        public string GetRandom5StarWeapon()
        {

            string query = "SELECT reward_name FROM WeaponRewards WHERE reward_tier = 5 ORDER BY RANDOM() LIMIT 1;";

            string databasePath = "Data Source=zenless_rewards.db";

            using (SqliteConnection connection = new SqliteConnection(databasePath))
            {

                connection.Open();

                SqliteCommand get5StarWeapons = new SqliteCommand(query, connection);

                string random5StarWeapon = (string)get5StarWeapons.ExecuteScalar();


                connection.Close();

                return random5StarWeapon;

            }

        }



        // ============================================================================================ //
        // ============================================================================================ //
        // CHARACTER ROLLS
        // ============================================================================================ //
        // ============================================================================================ //



        public string GetRandom4StarCharacter()
        {

            string query = "SELECT reward_name FROM CharacterRewards WHERE reward_tier = 4 ORDER BY RANDOM() LIMIT 1;";

            string databasePath = "Data Source=zenless_rewards.db";

            using (SqliteConnection connection = new SqliteConnection(databasePath))
            {

                connection.Open();

                SqliteCommand get4StarCharacters = new SqliteCommand(query, connection);

                string random4StarCharacter = (string)get4StarCharacters.ExecuteScalar();


                connection.Close();

                return random4StarCharacter;

            }

        }

        public string GetRandom5StarCharacter()
        {

            string query = "SELECT reward_name FROM CharacterRewards WHERE reward_tier = 5 ORDER BY RANDOM() LIMIT 1;";

            string databasePath = "Data Source=zenless_rewards.db";

            using (SqliteConnection connection = new SqliteConnection(databasePath))
            {

                connection.Open();

                SqliteCommand get5StarCharacters = new SqliteCommand(query, connection);

                string random5StarCharacter = (string)get5StarCharacters.ExecuteScalar();


                connection.Close();

                return random5StarCharacter;

            }


        }

    }
}
