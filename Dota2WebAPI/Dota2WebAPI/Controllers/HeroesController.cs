using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dota2WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        public static Model.Dota2DataBaseContext db = new Model.Dota2DataBaseContext();
        // GET: api/<HeroesController>
        [HttpGet]
        public List<Model.Hero> GetAllHero()
        {
            return db.Heroes.ToList();
        }

        // GET api/<HeroesController>/5
        [HttpGet("{id}")]
        public Model.Hero GetById(int id)
        {
            Model.Hero hero = db.Heroes.FirstOrDefault(c => c.Id == id);
            return hero;
        }

        // POST api/<HeroesController>
        [HttpPost]
        public void Post([FromBody] Model.Hero hero)
        {
            db.Heroes.Add(hero);
            db.SaveChanges();
        }

        // PUT api/<HeroesController>/5
        [HttpPut("{id}")]
        public void PutById(int id, [FromBody] Model.Hero hero)
        {
            Model.Hero dbHero = db.Heroes.FirstOrDefault(c => c.Id == id);
            dbHero.Name = hero.Name;
            dbHero.Strength = hero.Strength;
            dbHero.Agility = hero.Agility;
            dbHero.Intelligence = hero.Intelligence;
            dbHero.HealthPoint = hero.HealthPoint;
            dbHero.ArmorPoint = hero.ArmorPoint;
            dbHero.ManaPoint = hero.ManaPoint;
            dbHero.MoveSpeed = hero.MoveSpeed;
            dbHero.AttackSpeed = hero.AttackSpeed;
            dbHero.Avatar = hero.Avatar;
            db.SaveChanges();

            // Лучше было бы заполнить поля с помощью конструктора класса
            
        }

        // DELETE api/<HeroesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            db.Heroes.Remove(db.Heroes.FirstOrDefault(c => c.Id == id));
            db.SaveChanges();
        }
    }
}
