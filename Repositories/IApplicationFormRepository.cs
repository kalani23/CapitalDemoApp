using CapitalPlacement.Models.Entities;

namespace CapitalPlacement.Repositories
{
    public interface IApplicationFormRepository
    {
       Task <ApplicationFormField> CreateFormFieldAsync (ApplicationFormField field);
       Task<List<ApplicationFormField>> GetFormFieldByType(FieldType type);
       Task<ApplicationFormField> EditFormFieldAsync(Guid id, ApplicationFormField field);
       Task DeleteFormFieldAsync(Guid id);
    }
}
