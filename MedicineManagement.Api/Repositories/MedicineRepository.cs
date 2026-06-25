using System.Text.Json;
using MedicineManagement.Api.Entities;

namespace MedicineManagement.Api.Repositories;

public class MedicineRepository : IMedicineRepository
{
    private readonly string _filePath;

    public MedicineRepository(IWebHostEnvironment environment)
    {
        _filePath = Path.Combine(
            environment.ContentRootPath,
            "Data",
            "medicines.json");
    }

    public async Task<IEnumerable<Medicine>> GetAllAsync()
    {
        return await ReadMedicinesAsync();
    }

    public async Task<Medicine?> GetByIdAsync(int id)
    {
        var medicines = await ReadMedicinesAsync();

        return medicines.FirstOrDefault(m => m.Id == id);
    }

    public async Task AddAsync(Medicine medicine)
    {
        var medicines = await ReadMedicinesAsync();

        medicine.Id = medicines.Any()
            ? medicines.Max(m => m.Id) + 1
            : 1;

        medicines.Add(medicine);

        await SaveMedicinesAsync(medicines);
    }

    public async Task UpdateAsync(Medicine medicine)
    {
        var medicines = await ReadMedicinesAsync();

        var existingMedicine = medicines.FirstOrDefault(m => m.Id == medicine.Id);

        if (existingMedicine == null)
        {
            return;
        }

        existingMedicine.FullName = medicine.FullName;
        existingMedicine.Notes = medicine.Notes;
        existingMedicine.ExpiryDate = medicine.ExpiryDate;
        existingMedicine.Quantity = medicine.Quantity;
        existingMedicine.Price = medicine.Price;
        existingMedicine.Brand = medicine.Brand;

        await SaveMedicinesAsync(medicines);
    }

    public async Task DeleteAsync(int id)
    {
        var medicines = await ReadMedicinesAsync();

        var medicine = medicines.FirstOrDefault(m => m.Id == id);

        if (medicine == null)
        {
            return;
        }

        medicines.Remove(medicine);

        await SaveMedicinesAsync(medicines);
    }

    private async Task<List<Medicine>> ReadMedicinesAsync()
    {
        if (!File.Exists(_filePath))
        {
            await File.WriteAllTextAsync(_filePath, "[]");
        }

        var json = await File.ReadAllTextAsync(_filePath);

        return JsonSerializer.Deserialize<List<Medicine>>(json)
            ?? new List<Medicine>();
    }

    private async Task SaveMedicinesAsync(List<Medicine> medicines)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        var json = JsonSerializer.Serialize(medicines, options);

        await File.WriteAllTextAsync(_filePath, json);
    }
}