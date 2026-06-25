using MedicineManagement.Api.Entities;
using MedicineManagement.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedicineManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MedicinesController : ControllerBase
{
    private readonly IMedicineService _medicineService;

    public MedicinesController(IMedicineService medicineService)
    {
        _medicineService = medicineService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Medicine>>> GetAllMedicines()
    {
        var medicines = await _medicineService.GetAllAsync();

        return Ok(medicines);
    }

    [HttpPost]
    public async Task<IActionResult> AddMedicine([FromBody] Medicine medicine)
    {
        await _medicineService.AddAsync(medicine);

        return CreatedAtAction(
            nameof(GetMedicineById),
            new { id = medicine.Id },
            medicine);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Medicine>> GetMedicineById(int id)
    {
        var medicine = await _medicineService.GetByIdAsync(id);

        if (medicine == null)
        {
            return NotFound();
        }
        return Ok(medicine);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMedicine(int id, Medicine medicine)
    {
        if (id != medicine.Id)
        {
            return BadRequest("Route id and Medicine id do not match.");
        }

        var existingMedicine = await _medicineService.GetByIdAsync(id);

        if (existingMedicine == null)
        {
            return NotFound();
        }

        await _medicineService.UpdateAsync(medicine);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMedicine(int id)
    {
        var existingMedicine = await _medicineService.GetByIdAsync(id);

        if (existingMedicine == null)
        {
            return NotFound();
        }

        await _medicineService.DeleteAsync(id);

        return NoContent();
    }




}