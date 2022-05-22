
using CleaningSolution.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CleaningSolution.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CPController : ControllerBase
    {
        private readonly ICleaningPlan ics;
        private static bool added = false;
        public CPController(ICleaningPlan ics)
        {
            this.ics = ics;

            if (!added)
            {
                CleaningPlan_Impl a = new CleaningPlan_Impl
                {
                    id = Guid.Parse("8c442581-c67a-41e5-8d2d-b1176de31087"),
                    createdAt = DateTime.Now,
                    customerId = 123223,
                    title = "Hotel Room Cleaning, double bed",
                    description = "This plan is meant to be used for double bed rooms."
                };

                CleaningPlan_Impl b = new CleaningPlan_Impl
                {
                    createdAt = DateTime.Now,
                    customerId = 123223,
                    title = "Mall Cleaning, inner city",
                    description = "Suitable only for malls smaller than 23000 m²."
                };

                CleaningPlan_Impl c = new CleaningPlan_Impl
                {
                    createdAt = DateTime.Now,
                    customerId = 144444,
                    title = "Ciscenje ureda",
                    description = "Samo za poslovne svrhe."
                };

                ics.Add(a);
                ics.Add(b);
                ics.Add(c);

                added = true;
            }
        }


        [HttpGet]
        [Route("GetCleaningPlans")]
        public async Task<ActionResult> GetCleaningPlans()
        {
            try
            {
                return Ok(await ics.Get_All());
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        //[HttpGet("{id}")]
        [HttpGet]
        [Route("GetByCId")]
        public async Task<ActionResult<CleaningPlan_Impl>> GetByCId(int id)
        {
            try
            {
                var result = await ics.Get_By_cId(id);

                return result == null ? NotFound() : Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        
        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<CleaningPlan_Impl>> GetById(Guid guid)
        {
            try
            {
                var result = await ics.Get_By_Guid(guid);

                return result == null ? NotFound() : Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Creates a CP.
        /// </summary>
        /// <param name="cp"></param>
        /// <returns>A newly created CP</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /CleaningPlan
        ///     {
        ///         "title": "Name",
        ///         "customerId": 1123454,
        ///         "description": "Some description"
        ///     }
        ///     
        /// </remarks>
        /// <response code="200">Returns the newly created CP</response>
        /// <response code="404">If the item is null</response>
        [HttpPost]
        [Route("Add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CleaningPlan_Impl>> Add(CleaningPlan_Impl cp)
        {
            try
            {
                var result = await ics.Add(cp);

                return result == null ? NotFound() : Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        // just for my info  https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-6.0&tabs=visual-studio

        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult<CleaningPlan_Impl>> Update(Guid guid, CleaningPlan_Impl cp)
        {
            try
            {
                var result = await ics.Update_By_Id(guid, cp);

                return result == null ? NotFound() : Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Deletes a specific Cleaning Plan.
        /// </summary>
        /// <param name="CustomerID"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CleaningPlan_Impl>> Delete(int CustomerID)
        {
            try
            {
                var result = await ics.Delete_By_ID(CustomerID);

                return result == null ? NotFound() : Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

