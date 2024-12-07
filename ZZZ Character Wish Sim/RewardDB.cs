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


        // DB Creation queries
        // Tables for Weapons and Characters
        // Tables only have reward name, the reward tier (3 or B, 4 or A, and 5 or S), and typings
        // Actual queries to these tables ususally only pull in reward name and image path

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
                    ("Anby", 4, "Stun", "Electric", "pack://application:,,,/Resources/Images/Agent_Anby_Demara_Icon.png"),
                    ("Piper", 4, "Attack", "Physical", "pack://application:,,,/Resources/Images/Agent_Piper_Wheel_Icon.png"),
                    ("Billy", 4, "Attack", "Physical", "pack://application:,,,/Resources/Images/Agent_Billy_Kid_Icon.png"),
                    ("Ben", 4, "Defense", "Fire", "pack://application:,,,/Resources/Images/Agent_Anby_Demara_Icon.png"),
                    ("Corin", 4, "Attack", "Physical", "pack://application:,,,/Resources/Images/Agent_Corin_Wickes_Icon.png"),
                    ("Anton", 4, "Attack", "Physical", "pack://application:,,,/Resources/Images/Agent_Anton_Ivannov_Icon.png"),
                    ("Seth", 4, "Defense", "Electric", "pack://application:,,,/Resources/Images/Agent_Seth_Lowell_Icon.png"),
                    ("Soukaku", 4, "Support", "Ice", "pack://application:,,,/Resources/Images/sokauku.png"),
                    ("Lucy", 4, "Support", "Fire", "pack://application:,,,/Resources/Images/Agent_Luciana_de_Montefio_Icon.png"),
                    ("Nicole", 4, "Support", "Ether", "pack://application:,,,/Resources/Images/Agent_Nicole_Demara_Icon.png"),
                    ("Caesar", 5, "Defense", "Physical", "pack://application:,,,/Resources/Images/Agent_Caesar_King_Icon.png"),
                    ("Yanagi", 5, "Anomaly", "Electric", "pack://application:,,,/Resources/Images/Agent_Tsukishiro_Yanagi_Icon.png"),
                    ("Burnice", 5, "Anomaly", "Fire", "pack://application:,,,/Resources/Images/Agent_Burnice_White_Icon.png"),
                    ("Zhu Yuan", 5, "Attack", "Ether", "pack://application:,,,/Resources/Images/Agent_Zhu_Yuan_Icon.png"),
                    ("Jane Doe", 5, "Attack", "Physical", "pack://application:,,,/Resources/Images/Agent_Jane_Doe_Icon.png"),
                    ("Ellen Joe", 5, "Attack", "Ice", "pack://application:,,,/Resources/Images/Agent_Ellen_Joe_Icon.png"),
                    ("Qingyi", 5, "Stun", "Electric", "pack://application:,,,/Resources/Images/Agent_Qingyi_Icon.png"),
                    ("Lighter", 5, "Stun", " Fire", "pack://application:,,,/Resources/Images/Agent_Lighter_Icon.png"),
                    ("Lyacon", 5, "Stun", "Ice", "pack://application:,,,/Resources/Images/Agent_Von_Lycaon_Icon.png"),
                    ("Grace", 5, "Anomaly", "Electric", "pack://application:,,,/Resources/Images/Agent_Grace_Howard_Icon.png"),
                    ("Soldier 11", 5, "Attack", "Fire", "pack://application:,,,/Resources/Images/Agent_Soldier_11_Icon.png"),
                    ("Koleda", 5, "Stun", "Fire", "pack://application:,,,/Resources/Images/Agent_Koleda_Belobog_Icon.png"),
                    ("Rina", 5, "Support", "Electric", "pack://application:,,,/Resources/Images/Agent_Alexandrina_Sebastiane_Icon.png"),
                    ("Nekomata", 5, "Attack", "Physical", "pack://application:,,,/Resources/Images/Agent_Nekomiya_Mana_Icon.png")
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

                // Executes create table queries
                createWeaponsTable.ExecuteNonQuery();
                createCharactersTable.ExecuteNonQuery();

                // Loops through all items in charRewards and adds the specific values to the characters table
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

                // Loops through all items in weaponRewards and adds the specific values to the weapons table
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



        public (string, string) GetRandom3Star()
        {

            string query = "SELECT reward_name, reward_image_path FROM WeaponRewards WHERE reward_tier = 3 ORDER BY RANDOM() LIMIT 1;";

            string databasePath = "Data Source=zenless_rewards.db";

            using (SqliteConnection connection = new SqliteConnection(databasePath))
            {

                connection.Open();

                SqliteCommand get3Stars = new SqliteCommand(query, connection);

                SqliteDataReader reader = get3Stars.ExecuteReader();

                if (reader.Read())
                {

                    string weaponName = reader.GetString(0);
                    string weaponImgPath = reader.GetString(1);

                    return (weaponName, weaponImgPath);

                }

                connection.Close();

                return (null, null);

            }

        }

        public (string, string) GetRandom4StarWeapon()
        {

            string query = "SELECT reward_name, reward_image_path FROM WeaponRewards WHERE reward_tier = 4 ORDER BY RANDOM() LIMIT 1;";

            string databasePath = "Data Source=zenless_rewards.db";

            using (SqliteConnection connection = new SqliteConnection(databasePath))
            {

                connection.Open();

                SqliteCommand get4StarWeapons = new SqliteCommand(query, connection);

                SqliteDataReader reader = get4StarWeapons.ExecuteReader();

                if (reader.Read())
                {

                    string weaponName = reader.GetString(0);
                    string weaponImgPath = reader.GetString(1);

                    return (weaponName, weaponImgPath);

                }


                connection.Close();

                return (null, null);

            }

        }

        public (string, string) GetRandom5StarWeapon()
        {

            string query = "SELECT reward_name, reward_image_path FROM WeaponRewards WHERE reward_tier = 5 ORDER BY RANDOM() LIMIT 1;";

            string databasePath = "Data Source=zenless_rewards.db";

            using (SqliteConnection connection = new SqliteConnection(databasePath))
            {

                connection.Open();

                SqliteCommand get5StarWeapons = new SqliteCommand(query, connection);

                SqliteDataReader reader = get5StarWeapons.ExecuteReader();

                if (reader.Read())
                {

                    string weaponName = reader.GetString(0);
                    string weaponImgPath = reader.GetString(1);

                    return (weaponName, weaponImgPath);

                }


                connection.Close();

                return (null, null);

            }

        }



        // ============================================================================================ //
        // ============================================================================================ //
        // CHARACTER ROLLS
        // ============================================================================================ //
        // ============================================================================================ //



        public (string, string) GetRandom4StarCharacter()
        {

            string query = "SELECT reward_name, reward_image_path FROM CharacterRewards WHERE reward_tier = 4 ORDER BY RANDOM() LIMIT 1;";

            string databasePath = "Data Source=zenless_rewards.db";

            using (SqliteConnection connection = new SqliteConnection(databasePath))
            {

                connection.Open();

                SqliteCommand get4StarCharacters = new SqliteCommand(query, connection);

                SqliteDataReader reader = get4StarCharacters.ExecuteReader();

                if (reader.Read())
                {

                    string characterName = reader.GetString(0);
                    string characterImgPath = reader.GetString(1);

                    return (characterName, characterImgPath);

                }

                connection.Close();

                return (null, null);

            }

        }

        public (string, string) GetRandom5StarCharacter()
        {

            string query = "SELECT reward_name, reward_image_path FROM CharacterRewards WHERE reward_tier = 5 ORDER BY RANDOM() LIMIT 1;";

            string databasePath = "Data Source=zenless_rewards.db";

            using (SqliteConnection connection = new SqliteConnection(databasePath))
            {

                connection.Open();

                SqliteCommand get5StarCharacters = new SqliteCommand(query, connection);

                SqliteDataReader reader = get5StarCharacters.ExecuteReader();

                if (reader.Read()) { 
                
                    string characterName = reader.GetString(0);
                    string characterImgPath = reader.GetString(1);


                    return (characterName, characterImgPath);

                }


                connection.Close();

                return (null, null);

            }


        }

    }
}
