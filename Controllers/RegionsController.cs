using DemoAPI.Data;
using DemoAPI.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NzWalksDbContext dbContext;
        public RegionsController(NzWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            var regions = dbContext.Regions.ToList();
            return Ok(regions);

        }

        [HttpGet]
        [Route ("{id:guid}")]

        public IActionResult GetByID([FromRoute] Guid id)
        {

            var regions = dbContext.Regions.Find(id);

        if (regions == null)
        {
            return NotFound();
        }
            return Ok(regions);

        }

        /*public IActionResult GetAll() 
        {
            var regions = new List<Region>
            {
                new Region
                {
                    Id=Guid.NewGuid(),
                    RegionName="Auckland",
                    RegionCode="AUK",
                    RegionImageURL=""
           
                },
                new Region
                {
                    Id=Guid.NewGuid(),
                    RegionName="Wellington",
                    RegionCode="WLT",
                    RegionImageURL=""

                },
                new Region
                {
                    Id=Guid.NewGuid(),
                    RegionName="Auckland",
                    RegionCode="AUK",
                    RegionImageURL=""

                }
                

            };
            return Ok(regions);
        }*/


    }
}
