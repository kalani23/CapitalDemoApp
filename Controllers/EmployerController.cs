using CapitalPlacement.Models.DTOs;
using CapitalPlacement.Models.Entities;
using CapitalPlacement.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ApplicationFormController : ControllerBase
{
    private readonly IFormCreatorService _formCreatorService;

    public ApplicationFormController(IFormCreatorService formCreatorService)
    {
        _formCreatorService = formCreatorService;
    }

    [HttpPost("create-form-field")]
    public async Task<IActionResult> CreateFormField([FromBody] ApplicationFormFieldDto fieldDto)
    {
        try
        {
            var createdField = await _formCreatorService.CreateFormFieldAsync(fieldDto);
            return Ok(createdField);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(500, "An error occurred while processing the request.");
        }
    }

    [HttpGet("get-form-fields")]
    public async Task<IActionResult> GetFormFieldsByType([FromQuery] FieldType type)
    {
        try
        {
            var formFields = await _formCreatorService.GetFormFieldsByTypeAsync(type);
            if (formFields == null || formFields.Count == 0)
            {
                return NotFound("No form fields found for the specified type");
            }
            return Ok(formFields);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(500, "An error occurred while processing the request.");
        }
    }

    [HttpPut("edit-form-field/{id}")]
    public async Task<IActionResult> EditFormField(Guid id, [FromBody] ApplicationFormFieldDto updatedFieldDto)
    {
        try
        {
            var editedField = await _formCreatorService.EditFormFieldAsync(id, updatedFieldDto);
            return Ok(editedField);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(500, "An error occurred while processing the request.");
        }
    }

    [HttpDelete("delete-form-field/{id}")]
    public async Task<IActionResult> DeleteFormField(Guid id)
    {
        try
        {
            await _formCreatorService.DeleteFormFieldAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(500, "An error occurred while processing the request.");
        }
    }
}
