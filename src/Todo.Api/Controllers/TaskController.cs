using System.Net;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Todo.Core.Models;
using Todo.Data;

namespace Todo.Api.Controllers;

public class TaskController : Controller
{
    private ApplicationDBContext _db;
    public TaskController(ApplicationDBContext db)
    {
        _db = db;
    }

    [HttpGet]
    public IActionResult GetAllChallenges()
    {
        var listChallenges = ChallengesList();

        return Json(listChallenges);
    }

    [HttpPost]
    public IActionResult AddChallenge(Challenge challenge)
    {
        if (ModelState.IsValid)
        {
            _db.Set<Challenge>().Add(challenge);
            _db.SaveChanges();
        }

        var listChallenges = ChallengesList();

        return Json(listChallenges);
    }

    [HttpDelete]
    public IActionResult DeleteChallenge(Guid id)
    {
        var selectedChallenge = _db.Set<Challenge>().Find(id);

        if (selectedChallenge == null)
            return NotFound();

        _db.Set<Challenge>().Remove(selectedChallenge);
        _db.SaveChanges();

        var listChallenges = ChallengesList();

        return Json(listChallenges); 
    }
    
    private List<Challenge> ChallengesList()
    {
        var listData = _db.Set<Challenge>().ToList();

        return listData;
    }
}