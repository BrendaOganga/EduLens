
using EduLens.Application.Interfaces;
using EduLens.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduLens.Infrastructure.Data.Repositories;

public class PredictionRepository : IPredictionRepository
{
    private readonly EduLensDbContext _context;

    public PredictionRepository(EduLensDbContext context)
    {
        _context = context;
    }

    public async Task<Prediction?> GetByIdAsync(int id)
    {
        return await _context.Predictions
            .Include(p => p.Student)
            .ThenInclude(s => s.User)
            .FirstOrDefaultAsync(p => p.PredictionId == id);
    }

    public async Task<IEnumerable<Prediction>> GetAllAsync()
    {
        return await _context.Predictions
            .Include(p => p.Student)
            .ToListAsync();
    }

    public async Task<Prediction> CreateAsync(Prediction prediction)
    {
        await _context.Predictions.AddAsync(prediction);
        await _context.SaveChangesAsync();

        return await GetByIdAsync(prediction.PredictionId) ?? prediction;
    }

    public async Task UpdateAsync(Prediction prediction)
    {
        var existingPrediction = await _context.Predictions
            .FirstOrDefaultAsync(p => p.PredictionId == prediction.PredictionId);

        if (existingPrediction == null)
            throw new KeyNotFoundException("Prediction not found.");

        existingPrediction.RiskLevel = prediction.RiskLevel;
        existingPrediction.Probability = prediction.Probability;
        existingPrediction.ModelVersion = prediction.ModelVersion;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Prediction prediction)
    {
        _context.Predictions.Remove(prediction);
        await _context.SaveChangesAsync();
    }
}
