using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.API.Dto;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using Student.API.Models;

namespace Student.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChampionsController : ControllerBase
    {
        private readonly string connectionString;

        public ChampionsController(){
            connectionString = "server=localhost; database=league_of_legends;uid=root;password=Midhi003*;";
        }

        [HttpGet("Get All Champions")]
        public IActionResult GetChampions()
        {
            var champions = new List<Student.API.Models.Champion>();
            // List of all Champions
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM champions", connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while(reader.Read())
                    {
                        var champion = new Student.API.Models.Champion()
                        {
                            Id = reader.GetInt64(0),
                            FullName = reader.GetString(1),
                            Role = reader.GetString(2),
                            AttackDamage = reader.GetFloat(3),
                            AbilityPower = reader.GetFloat(4),
                            Health = reader.GetFloat(5),
                            AttackSpeed = reader.GetFloat(6),
                            Mana = reader.GetFloat(7),
                            Armor = reader.GetFloat(8),
                            MagicResist = reader.GetFloat(9),
                            CritDamage = reader.GetFloat(10),
                            MovementSpeed = reader.GetFloat(11),
                            AttackRange = reader.GetFloat(12)
                        };
                        champions.Add(champion);
                    }
                    reader.Close();
                }
                return Ok(champions);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Database error: {e.Message}");
            }
        }
            
        [HttpGet("Get By Id")]
        public IActionResult GetChampionById(long id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM champions WHERE champid= @id", connection);
                    command.Parameters.AddWithValue("@id",id);
                    MySqlDataReader reader = command.ExecuteReader();

                    if(reader.Read())
                    {
                        var champion = new Student.API.Models.Champion()
                        {
                            Id = reader.GetInt64(0),
                            FullName = reader.GetString(1),
                            Role = reader.GetString(2),
                            AttackDamage = reader.GetFloat(3),
                            AbilityPower = reader.GetFloat(4),
                            Health = reader.GetFloat(5),
                            AttackSpeed = reader.GetFloat(6),
                            Mana = reader.GetFloat(7),
                            Armor = reader.GetFloat(8),
                            MagicResist = reader.GetFloat(9),
                            CritDamage = reader.GetFloat(10),
                            MovementSpeed = reader.GetFloat(11),
                            AttackRange = reader.GetFloat(12)
                        };
                        reader.Close();
                        return Ok(champion);
                    }
                    else
                    {
                        reader.Close();
                        return NotFound();
                    }
                }
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Database Error: {e.Message}");
            }
        }


        [HttpPost("Add New Champion")]
        public IActionResult AddNewChampion([FromBody] PostChampionDto payload)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("INSERT INTO champions (name, role, attack_damage, ability_power, health, attack_speed, mana, armor, magic_resist, crit_damage, movement_speed, attack_range) VALUES (@name, @role, @attack_damage, @ability_power, @health, @attack_speed, @mana, @armor, @magic_resist, @crit_damage, @movement_speed, @attack_range)", connection);
                    command.Parameters.AddWithValue("@name", payload.FullName);
                    command.Parameters.AddWithValue("@role", payload.Role);
                    command.Parameters.AddWithValue("@attack_damage", payload.AttackDamage);
                    command.Parameters.AddWithValue("@ability_power", payload.AbilityPower);
                    command.Parameters.AddWithValue("@health", payload.Health);
                    command.Parameters.AddWithValue("@attack_speed", payload.AttackSpeed);
                    command.Parameters.AddWithValue("@mana", payload.Mana);
                    command.Parameters.AddWithValue("@armor", payload.Armor);
                    command.Parameters.AddWithValue("@magic_resist", payload.MagicResist);
                    command.Parameters.AddWithValue("@crit_damage", payload.CritDamage);
                    command.Parameters.AddWithValue("@movement_speed", payload.MovementSpeed);
                    command.Parameters.AddWithValue("@attack_range", payload.AttackRange);
                    command.ExecuteNonQuery();
                }
                return Ok(payload);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Database Error: {e.Message}");
            }
        }

        [HttpDelete("Delete By Id")]
        public IActionResult DeleteChampion(long id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("DELETE FROM champions WHERE champid = @id", connection);
                    command.Parameters.AddWithValue("@id", id);
                    long rowsAffected = command.ExecuteNonQuery();

                    if(rowsAffected > 0)
                    {
                        return Ok($"Champion with ID {id} was deleted successfully.");
                    }
                    else
                    {
                        return NotFound($"Champion with ID {id} doesnt exist.");
                    }
                }
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Database Error: {e.Message}");
            }
        }

        [HttpDelete("Delete By Name")]
        public IActionResult DeleteChampionByName(string name)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("DELETE FROM champions WHERE name = @name", connection);
                    command.Parameters.AddWithValue("@name", name);
                    long rowsAffected = command.ExecuteNonQuery();

                    if(rowsAffected > 0)
                    {
                        return Ok($"Champion with Name {name} was deleted successfully.");
                    }
                    else
                    {
                        return NotFound($"Champion with Name {name} doesnt exist.");
                    }
                }
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Database Error: {e.Message}");
            }
        }
    }
}


        

