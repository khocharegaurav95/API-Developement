using DemoAPI.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        public RegionsController() { }

        [HttpGet]

        public IActionResult GetAll() 
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
                    Id=new Guid(),
                    RegionName="Auckland",
                    RegionCode="AUK",
                    RegionImageURL=""

                }
                

            };
            return Ok(regions);
        }

        
    }
}
