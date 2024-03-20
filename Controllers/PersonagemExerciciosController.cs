using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RpgAPI.Models;
using RpgAPI.Models.Enuns;


namespace RpgAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PersonagemExerciciosController : Controller
    {
        private static List<Personagem> personagens = new List<Personagem>()
        {
            //Colar os objetos da lista do chat aqui
            new Personagem() { Id = 1, Nome = "Frodo", PontosVida=100, Forca=17, Defesa=23, Inteligencia=33, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 2, Nome = "Sam", PontosVida=100, Forca=15, Defesa=25, Inteligencia=30, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 3, Nome = "Galadriel", PontosVida=100, Forca=18, Defesa=21, Inteligencia=35, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 4, Nome = "Gandalf", PontosVida=100, Forca=18, Defesa=18, Inteligencia=37, Classe=ClasseEnum.Mago },
            new Personagem() { Id = 5, Nome = "Hobbit", PontosVida=100, Forca=20, Defesa=17, Inteligencia=31, Classe=ClasseEnum.Cavaleiro },
            new Personagem() { Id = 6, Nome = "Celeborn", PontosVida=100, Forca=21, Defesa=13, Inteligencia=34, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 7, Nome = "Radagast", PontosVida=100, Forca=25, Defesa=11, Inteligencia=35, Classe=ClasseEnum.Mago }
        };

        [HttpGet("GetByName/{nome}")]
        public IActionResult GetByName(string nome)
        {
            List<Personagem> listaBusca = personagens.FindAll(p => p.Nome == nome);

            return Ok(listaBusca);
            
        }

        [HttpPost("PostValid")]
        public IActionResult PostValid(Personagem newPersonagem)
        {
            if(newPersonagem.Defesa < 10 || newPersonagem.Inteligencia > 35)
            {
                return BadRequest("Não pode ser adicionado");
            }
            
            personagens.Add(newPersonagem);
            return Ok(personagens);

        }

        [HttpGet("GetClerigo")]

        public IActionResult GetClerigo()
        {
            personagens.RemoveAll(p => p.Classe == ClasseEnum.Cavaleiro);
            return Ok("Personagems Removidos: " + personagens);

        }

        [HttpPost("PostValidMago")]
        public IActionResult PostValidMago (Personagem newPersonagem)
        {
            if(newPersonagem.Classe = 2 && newPersonagem.Inteligencia < 35)
            {
                return BadRequest("Não pode ser adicionado");
            }
            
            personagens.Add(newPersonagem);
            return Ok(personagens);

        }

        [HttpGet("GetEstatistica")]

        public IActionResult GetEstic()
        {
            return Ok( "Quant Personagens: " + personagens.Count);
            
        }
        

        

        
    }
}