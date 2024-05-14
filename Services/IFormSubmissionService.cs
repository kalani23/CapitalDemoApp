using CapitalPlacement.Models.DTOs;

namespace CapitalPlacement.Services
{
    public interface IFormSubmissionService
    {
        Task<FormSubmissionDto> SubmitFormAsync(FormSubmissionDto formDto);
        Task<List<FormSubmissionDto>> GetDetailsAsync();

    }
}
