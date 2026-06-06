using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace StudentsController
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public StudentsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("jmbags")]
        public IActionResult GetJmbags()
        {
            List<string> jmbags = new();

            using SqlConnection con =
                new(_configuration.GetConnectionString("ISVU"));

            con.Open();

            string sql = "SELECT Jmbag FROM Student ORDER BY Jmbag";

            using SqlCommand cmd = new(sql, con);

            using SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                jmbags.Add(dr["Jmbag"].ToString());
            }

            return Ok(jmbags);
        }

        [HttpPost]
        public IActionResult AddStudent([FromBody] Student student)
        {
            return Ok($"Etudiant avec JMBAG {student.Jmbag} recu.");
        }
    }
}