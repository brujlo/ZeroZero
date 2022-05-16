using CleaningSolution.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CleaningSolution.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class Controller : ControllerBase
    {
        private readonly CleaningPlanDbContext _context;

        #region TrazenaVerzija

        public Controller(CleaningPlanDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetCPByCustomerId")]
        public IQueryable<CleaningPlan> GetCPByCustomerId(int id)
        {
            var cp = _context.CleaningPlans.Where(e => e.customerId == id);

            return cp;
        }

        [HttpGet]
        [Route("GetCPById")]
        public IQueryable<CleaningPlan> GetCPById(Guid guid)
        {
            var cp = _context.CleaningPlans.Where(e => e.id == guid);

            return cp;
        }

        [HttpDelete]
        [Route("DeletCPById")]
        public IActionResult DeleteById(Guid guid)
        {
            var cp = _context.CleaningPlans.SingleOrDefault(i => i.id == guid);

            if (cp == null) return NotFound("Cleaning plan not found!");

            _context.CleaningPlans.Remove(cp);
            _context.SaveChanges();

            return Ok("Cleaning plan wiht Id " + guid + " deleted Successfully");
        }

        [HttpPost]
        [Route("AddCP/{CleaningPlan}")]
        public IActionResult AddCleaningPlan(CleaningPlan cp)
        {
            cp.createdAt = DateTime.Now;

            _context.CleaningPlans.Add(cp);
            _context.SaveChanges();

            return Created("CleaningPlan/" + cp.customerId, cp);
        }

        [HttpPut]
        [Route("UpdateCPById")]
        public IActionResult UpdateCleaningPlanById(Guid guid, CleaningPlan _cp)
        {
            var cp = _context.CleaningPlans.SingleOrDefault(i => i.id == guid);

            if (cp == null) return NotFound("Cleaning plan not found!");

            if (_cp.title != null)
                cp.title = _cp.title;

            if (_cp.customerId != 0)
                cp.customerId = _cp.customerId;

            if (_cp.description != null)
                cp.description = _cp.description;

            _context.Update(cp);
            _context.SaveChanges();

            return Ok("Cleaning plan wiht Id " + guid + " updated Successfully");
        }

        #endregion

        #region ProsirenaVerzija

        //private static bool add = false;

        //public Controller(CleaningPlanDbContext context)
        //{
        //    _context = context;

        //    //da ih ne moram rucno dodavati
        //    if (!add)
        //    {
        //        CleaningPlan a = new CleaningPlan
        //        {
        //            id = Guid.Parse("8c442581-c67a-41e5-8d2d-b1176de31087"),
        //            createdAt = DateTime.Now,
        //            customerId = 123223,
        //            title = "Hotel Room Cleaning, double bed",
        //            description = "This plan is meant to be used for double bed rooms."
        //        };

        //        CleaningPlan b = new CleaningPlan
        //        {
        //            createdAt = DateTime.Now,
        //            customerId = 123223,
        //            title = "Mall Cleaning, inner city",
        //            description = "Suitable only for malls smaller than 23000 m²."
        //        };

        //        CleaningPlan c = new CleaningPlan
        //        {
        //            createdAt = DateTime.Now,
        //            customerId = 144444,
        //            title = "Ciscenje ureda",
        //            description = "Samo za poslovne svrhe."
        //        };

        //        _context.CleaningPlans.Add(a);
        //        _context.CleaningPlans.Add(b);
        //        _context.CleaningPlans.Add(c);
        //        _context.SaveChanges();
        //        add = true;
        //    }
        //}

        //[HttpGet]
        //[Route("GetCleaningPlans")]
        //public IEnumerable<CleaningPlan> GetCleaningPlans()
        //{
        //    return _context.CleaningPlans.ToList();
        //}


        //[HttpGet]
        //[Route("GetCPByCustomerId")]
        //public IQueryable<CleaningPlan> GetCPByCustomerId(int id)
        //{
        //    var cp = _context.CleaningPlans.Where(e => e.customerId == id);

        //    return cp;
        //}


        //[HttpGet]
        //[Route("GetCPById")]
        //public IQueryable<CleaningPlan> GetCPById(Guid guid)
        //{
        //    var cp = _context.CleaningPlans.Where(e => e.id == guid);

        //    return cp;
        //}


        //[HttpDelete]
        //[Route("DeletCPByCustomerId")] 
        //public IActionResult DeleteCustomerId(int id)
        //{
        //    var cpLst = _context.CleaningPlans.Where(i => i.customerId == id);

        //    if (cpLst == null || cpLst.Count() == 0) return NotFound("Cleaning plan not found!");

        //    foreach(CleaningPlan cp in cpLst)
        //        _context.CleaningPlans.Remove(cp);

        //    _context.SaveChanges();

        //    return Ok("Cleaning plan(s) wiht Id " + id + " deleted Successfully");
        //}


        //[HttpDelete]
        //[Route("DeletCPById")]
        //public IActionResult DeleteById(Guid guid)
        //{
        //    var cp = _context.CleaningPlans.SingleOrDefault(i => i.id == guid);

        //    if (cp == null) return NotFound("Cleaning plan not found!");

        //    _context.CleaningPlans.Remove(cp);
        //    _context.SaveChanges();

        //    return Ok("Cleaning plan wiht Id " + guid + " deleted Successfully");
        //}


        //[HttpPost]
        //[Route("AddCP/{CleaningPlan}")]
        //public IActionResult AddCleaningPlan(CleaningPlan cp)
        //{
        //    cp.createdAt = DateTime.Now;

        //    _context.CleaningPlans.Add(cp);
        //    _context.SaveChanges();

        //    return Created("CleaningPlan/" + cp.customerId, cp);
        //}


        //[HttpPut]
        //[Route("UpdateCPByCustomerId")]
        //public IActionResult UpdateCleaningPlanCustomerId(int id, CleaningPlan _cp)
        //{
        //    var cpLst = _context.CleaningPlans.Where(i => i.customerId == id);

        //    if (cpLst == null || cpLst.Count() == 0) return NotFound("Cleaning plan not found!");

        //    foreach(CleaningPlan cp in cpLst)
        //    {
        //        if (_cp.title != null)
        //            cp.title = _cp.title;

        //        if(_cp.description != null)
        //            cp.description = _cp.description;

        //        _context.Update(cp);
        //    }

        //    _context.SaveChanges();

        //    return Ok("Cleaning plan(s) wiht CustomerId " + id + " updated Successfully");
        //}


        //[HttpPut]
        //[Route("UpdateCPById")]
        //public IActionResult UpdateCleaningPlanById(Guid guid, CleaningPlan _cp)
        //{
        //    var cp = _context.CleaningPlans.SingleOrDefault(i => i.id== guid);

        //    if (cp == null) return NotFound("Cleaning plan not found!");

        //    if (_cp.title != null)
        //        cp.title = _cp.title;

        //    if (_cp.customerId != 0)
        //        cp.customerId = _cp.customerId;

        //    if (_cp.description != null)
        //        cp.description = _cp.description;

        //    _context.Update(cp);
        //    _context.SaveChanges();

        //    return Ok("Cleaning plan wiht Id " + guid + " updated Successfully");
        //}

        #endregion
    }
}


//private static readonly CleaningPlan[] cPlansLst = new[]
//{
//    new CleaningPlan
//    {
//        guid = Guid.NewGuid(),
//        date = DateTime.Now,
//        customerId = 1,
//        title = "Hotel Room Cleaning, double bed",
//        description = "This plan is meant to be used for double bed rooms."
//    },
//    new CleaningPlan
//    {
//        title = "Mall Cleaning, inner city",
//        description = "Suitable only for malls smaller than 23000 m²."
//    },

//};

