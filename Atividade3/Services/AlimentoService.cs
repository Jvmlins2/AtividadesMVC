using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Atividade3.Data; // Updated to the correct namespace
using Atividade3.Models; // Updated to the correct namespace

public class AlimentoService
{
    private readonly AppDbContext _context;

    public AlimentoService(AppDbContext context)
    {
        _context = context;
    }

    public List<Alimento> GetAllAlimentos()
    {
        return _context.Alimentos.ToList(); // Assuming Alimentos is the DbSet for Alimento
    }
}