namespace Business;

using System;

public class IncomeEntry : DatedEntity
{
    public string Description { get; }
    public decimal Amount { get; }
    public Client Client { get; }

    public IncomeEntry(string description, decimal amount, Client client, DateTime? date = null)
        : base(date)
    {
        Description = description ?? throw new ArgumentNullException(nameof(description));
        Amount = amount > 0 ? amount : throw new ArgumentException("Сумма должна быть положительной.");
        Client = client ?? throw new ArgumentNullException(nameof(client));
    }
}
