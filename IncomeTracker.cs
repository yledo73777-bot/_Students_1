namespace Business;

using System;
using System.Collections.Generic;
using System.Linq;

public class IncomeTracker
{
  public class SelfEmployedIncomeTracker
{
    private readonly List<IncomeEntry> _incomes = new();

    public void AddIncome(string description, decimal amount, Client client, DateTime? date = null)
    {
        var entry = new IncomeEntry(description, amount, client, date);
        _incomes.Add(entry);
    }


    public decimal GetMonthlyIncome(int year, int month) =>
        _incomes
            .Where(e => e.Date.Year == year && e.Date.Month == month)
            .Sum(e => e.Amount);
    
    public decimal GetPhysicalTax(int year, int month) =>
        _incomes
            .Where(e => e.Date.Year == year && e.Date.Month == month && e.Client.Type == ClientType.Physical)
            .Sum(e => e.Amount * 0.04m);
    
    public decimal GetLegalTax(int year, int month) =>
        _incomes
            .Where(e => e.Date.Year == year && e.Date.Month == month && e.Client.Type == ClientType.Legal)
            .Sum(e => e.Amount * 0.06m);
    
    public decimal GetTotalTax(int year, int month) => GetPhysicalTax(year, month) + GetLegalTax(year, month);

    public decimal GetProfit(int year, int month) => 
        GetMonthlyIncome(year, month) - GetTotalTax(year, month);
    
    public MonthlyAnalytics GetMonthlyAnalytics(int year, int month)
    {
        var income = GetMonthlyIncome(year, month);
        var physTax = GetPhysicalTax(year, month);
        var legalTax = GetLegalTax(year, month);
        var totalTax = physTax + legalTax;
        var profit = income - totalTax;

        return new MonthlyAnalytics(year, month, income, physTax, legalTax, totalTax, profit);
    }
}

public record MonthlyAnalytics(int Year, int Month, decimal TotalIncome, decimal PhysicalTax, 
    decimal LegalTax, decimal TotalTax, decimal Profit);
}

