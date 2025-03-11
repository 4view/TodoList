using System.Net;
using Microsoft.AspNetCore.Http.HttpResults;
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
    public IActionResult RemoveChallenge(Guid challengeID)
    {
        var savedChallenges = ChallengesList();
        var selectedChallenge = savedChallenges.Where(c => c.Id == challengeID);

        if (selectedChallenge == null)
        {
            return NotFound();
        }

        _db.Remove(selectedChallenge);
        _db.SaveChanges();

        return Json(savedChallenges);
    }

    private List<ChallengeEntity> ChallengesList()
    {
        var listData = _db.Set<ChallengeEntity>().ToList();

        return listData;
    }
}