using System.Net;
using Azure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Todo.Core.Entities;
using Todo.Core.Models;
using Todo.Data;

namespace Todo.Api.Controllers;

[Route("api/{controller}")]
public class TaskController : Controller
{
    private ApplicationDBContext _db;
    public TaskController(ApplicationDBContext db)
    {
        _db = db;
    }

    [HttpGet("Welcome")]
    public IActionResult Welcome()
    {
        return Json("Welcome");
    }

    [HttpGet("GetAllChallenges")]
    public IActionResult GetAllChallenges()
    {
        var listChallenges = _db.Set<Challenge>().ToList();
        //var listChallenges = ChallengesList();

        return Json(listChallenges);
    }

    [HttpPost("AddChallenge")]
    public IActionResult AddChallenge(Challenge challenge)// Это DTO, надо вывести в другой класс
    {
        if (ModelState.IsValid)
        {
            var addedChallenge = challenge.ToEntity();
            addedChallenge.Id = Guid.NewGuid();
            addedChallenge.CreationDate = addedChallenge.CreationDate.ToOffset(new TimeSpan(0));

            _db.Set<ChallengeEntity>().Add(addedChallenge);
            _db.SaveChanges();
        }

        var listChallenges = ChallengesList();

        return Json(listChallenges);
    }
    
    [HttpDelete("RemoveChallenge")]
    public IActionResult RemoveChallenge(Guid id)
    {
        var savedChallenges = ChallengesList();
        var selectedChallenge = savedChallenges.FirstOrDefault(c => c.Id == id);

        if (selectedChallenge == null)
        {
            return NotFound("Challenge not found");
        }

        _db.Set<ChallengeEntity>().Remove(selectedChallenge);
        _db.SaveChanges();

        return Json(savedChallenges);
    }

    [HttpPut("UpdateChallenge/{id}")]
    public IActionResult UpdateChallenge(
        [FromBody] JsonPatchDocument<ChallengeEntity> patchDoc, Guid id
    )
    {
        if (patchDoc != null)
        {
            var savedChallenges = ChallengesList();
            var selectedChallenge = savedChallenges.FirstOrDefault(c => c.Id == id);

            if (selectedChallenge == null)
            {
                return NotFound("Challenge not found");
            }

            patchDoc.ApplyTo(selectedChallenge, ModelState);

            _db.SaveChanges();

            return Json(savedChallenges);
        }
        else
        {
            return BadRequest(ModelState);
        }        
    }

    private List<ChallengeEntity> ChallengesList()
    {
        var listData = _db.Set<ChallengeEntity>().ToList();

        return listData;
    }
}