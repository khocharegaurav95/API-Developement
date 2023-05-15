using DemoAPI.Data;
using DemoAPI.Models.Domain;
using DemoAPI.Models.RegionDTO;
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
        [Route ("{id:Guid}")]

        public IActionResult GetByID([FromRoute] Guid id)
        {
            //get data from database
            //var regions= dbContext.Regions.FirstOrDefault(x=>x.Id==id);
            var regions = dbContext.Regions.Find(id);

            if (regions == null) 
            { 
            return NotFound();
            }

            return Ok(regions);

        }


        [HttpPost]
        public IActionResult CreateNewRegion([FromBody] AddRegionRequestDTO addRegionRequestDTO)
        {

            var regionDomainModel = new Region
            { 
                RegionCode = addRegionRequestDTO.RegionCode,
                RegionName=addRegionRequestDTO.RegionName,  
                RegionImageURL=addRegionRequestDTO.RegionImageURL
            };

            dbContext.Regions.Add(regionDomainModel);
            dbContext.SaveChanges();

            var regionDto = new RegionsDTO
            {
                Id = regionDomainModel.Id,
                RegionCode = regionDomainModel.RegionCode,
                RegionName = regionDomainModel.RegionName,
                RegionImageURL = regionDomainModel.RegionImageURL
            };

            return CreatedAtAction(nameof(GetByID),new {id=regionDomainModel.Id },regionDomainModel);
        }


        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult UpdateRegionData([FromRoute] Guid id,[FromBody]UpdateRegionDataRequestDTO updateRegionDataRequestDTO)
        {
            var regionsDomainModel = dbContext.Regions.FirstOrDefault(x => x.Id == id);

            if (regionsDomainModel == null)
            { 
            return NotFound();
            }

            regionsDomainModel.RegionCode = updateRegionDataRequestDTO.RegionCode;
            regionsDomainModel.RegionName = updateRegionDataRequestDTO.RegionName;
            regionsDomainModel.RegionImageURL= updateRegionDataRequestDTO.RegionImageURL;

            dbContext.SaveChanges();

            var regionDTO = new RegionsDTO
            {
                Id = regionsDomainModel.Id,
                RegionCode = regionsDomainModel.RegionCode,
                RegionName = regionsDomainModel.RegionName,
                RegionImageURL = regionsDomainModel.RegionImageURL
            };

            return Ok(regionDTO);

        }
        [HttpDelete]
        [Route("{id:Guid}")]

        public IActionResult DeleteRegion([FromRoute] Guid id)
        {
            var regionDomainModel = dbContext.Regions.FirstOrDefault(x => x.Id == id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            dbContext.Regions.Remove(regionDomainModel);

            dbContext.SaveChanges();

            var regionDTO = new RegionsDTO
            {
                Id = regionDomainModel.Id,
                RegionCode = regionDomainModel.RegionCode,
                RegionName = regionDomainModel.RegionName,
                RegionImageURL = regionDomainModel.RegionImageURL
            };

            return Ok(regionDTO);
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
