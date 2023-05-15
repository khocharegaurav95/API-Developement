using DemoAPI.Data;
using DemoAPI.Models.Domain;
using DemoAPI.Models.RegionDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IActionResult> GetAll()
        {
            var regions = await dbContext.Regions.ToListAsync();
            return Ok(regions);

        }

        [HttpGet]
        [Route ("{id:Guid}")]

        public async Task<IActionResult> GetByID([FromRoute] Guid id)
        {
            //get data from database
            //var regions= dbContext.Regions.FirstOrDefault(x=>x.Id==id);
            var regions =await dbContext.Regions.FindAsync(id);

            if (regions == null) 
            { 
            return NotFound();
            }

            return Ok(regions);

        }


        [HttpPost]
        public async Task<IActionResult> CreateNewRegion([FromBody] AddRegionRequestDTO addRegionRequestDTO)
        {

            var regionDomainModel = new Region
            { 
                RegionCode = addRegionRequestDTO.RegionCode,
                RegionName=addRegionRequestDTO.RegionName,  
                RegionImageURL=addRegionRequestDTO.RegionImageURL
            };

            await dbContext.Regions.AddAsync(regionDomainModel);
            await dbContext.SaveChangesAsync();

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
        public async Task<IActionResult> UpdateRegionData([FromRoute] Guid id,[FromBody]UpdateRegionDataRequestDTO updateRegionDataRequestDTO)
        {
            var regionsDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (regionsDomainModel == null)
            { 
            return NotFound();
            }

            regionsDomainModel.RegionCode = updateRegionDataRequestDTO.RegionCode;
            regionsDomainModel.RegionName = updateRegionDataRequestDTO.RegionName;
            regionsDomainModel.RegionImageURL= updateRegionDataRequestDTO.RegionImageURL;

            await dbContext.SaveChangesAsync();

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

        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        {
            var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            dbContext.Regions.Remove(regionDomainModel);

            await dbContext.SaveChangesAsync();

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
