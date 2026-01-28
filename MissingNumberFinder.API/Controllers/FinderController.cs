using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MissingNumberFinder.Contracts;
using MissingNumberFinder.Factory.Contracts;
using MissingNumberFinder.Factory.DataModels;

namespace MissingNumberFinder.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinderController(ILogger<FinderController> _logger, IAlgorithmFactory _factory) : Controller
    {
        [HttpPost("find")]
        public async Task<IActionResult> FindMissingNumber([FromBody] MissingNumberRequest request, CancellationToken ct)
        {
            var finder = _factory.CreateAlgorithm(new AlgorithmDataContext() { UserInputAlgorithm = request.AlgorithmName });
            var result = await finder.FindMissingNumberAsync(request.Numbers, ct);
            return Ok(result);
        }
    }
}
