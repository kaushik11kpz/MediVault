using MedicineManagement.Api.Entities;
using MedicineManagement.Api.Repositories;

namespace MedicineManagement.Api.Services;

public class MedicineService : IMedicineService
{
    private readonly IMedicineRepository _medicineRepository;

    public MedicineService(IMedicineRepository medicineRepository)
    {
        _medicineRepository = medicineRepository;
    }

    public async Task<IEnumerable<Medicine>> GetAllAsync()
    {
        return await _medicineRepository.GetAllAsync();
    }

    public async Task<Medicine?> GetByIdAsync(int id)
    {
        return await _medicineRepository.GetByIdAsync(id);
    }

    public async Task AddAsync(Medicine medicine)
    {
        await _medicineRepository.AddAsync(medicine);
    }

    public async Task UpdateAsync(Medicine medicine)
    {
        await _medicineRepository.UpdateAsync(medicine);
    }

    public async Task DeleteAsync(int id)
    {
        await _medicineRepository.DeleteAsync(id);
    }
}