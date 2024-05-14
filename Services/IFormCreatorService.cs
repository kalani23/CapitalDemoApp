using CapitalPlacement.Models.DTOs;
using CapitalPlacement.Models.Entities;

namespace CapitalPlacement.Services
{
    public interface IFormCreatorService
    {
        Task<ApplicationFormField> CreateFormFieldAsync(ApplicationFormFieldDto field);
        Task<List<ApplicationFormField>> GetFormFieldsByTypeAsync(FieldType type);
        Task<ApplicationFormField> EditFormFieldAsync(Guid id, ApplicationFormFieldDto updatedFieldDto);
        Task DeleteFormFieldAsync(Guid id);
    }
}
