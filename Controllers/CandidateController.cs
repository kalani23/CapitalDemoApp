using CapitalPlacement.Models.DTOs;
using CapitalPlacement.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CandidateController : ControllerBase
{
    private readonly IFormSubmissionService _formSubmissionService;

    public CandidateController(IFormSubmissionService formSubmissionService)
    {
        _formSubmissionService = formSubmissionService;
    }

    [HttpPost("submit-form")]
    public async Task<IActionResult> SubmitForm([FromBody] FormSubmissionDto formDto)
    {
        try
        {
            var submissionResult = await _formSubmissionService.SubmitFormAsync(formDto);
            return Ok(submissionResult);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(500, "An error occurred while processing the request.");
        }
    }

    [HttpGet("get-candidate-details")]
    public async Task<IActionResult> GetCandidateDetails()
    {
        try
        {
            var submissionResult = await _formSubmissionService.GetDetailsAsync();
            return Ok(submissionResult);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(500, "An error occurred while processing the request.");
        }
    }
}
