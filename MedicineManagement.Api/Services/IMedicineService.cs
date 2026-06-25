using MedicineManagement.Api.Entities;

namespace MedicineManagement.Api.Services;

public interface IMedicineService
{
    Task<IEnumerable<Medicine>> GetAllAsync();

    Task<Medicine?> GetByIdAsync(int id);

    Task AddAsync(Medicine medicine);

    Task UpdateAsync(Medicine medicine);

    Task DeleteAsync(int id);
}