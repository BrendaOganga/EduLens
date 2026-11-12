
using EduLens.Application.DTOs;
using EduLens.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EduLens.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PredictionsController : ControllerBase
{
    private readonly IPredictionService _predictionService;

    public PredictionsController(IPredictionService predictionService)
    {
        _predictionService = predictionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var predictions = await _predictionService.GetAllAsync();

        return Ok(predictions);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var prediction = await _predictionService.GetByIdAsync(id);

        if (prediction == null)
            return NotFound();

        return Ok(prediction);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePredictionDto predictionDto)
    {
        var prediction = await _predictionService.CreateAsync(predictionDto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = prediction.PredictionId },
            prediction);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        UpdatePredictionDto predictionDto)
    {
        var updated = await _predictionService.UpdateAsync(id, predictionDto);

        if (!updated)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _predictionService.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}

