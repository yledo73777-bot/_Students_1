namespace Business;

using System;

public class DatedEntity
{
    public DateTime Date { get; protected set; } = DateTime.Now;

    protected DatedEntity(DateTime? date = null)
    {
        if (date.HasValue && date.Value > DateTime.Now)
            throw new ArgumentException("Дата не может быть в будущем.");
        Date = date ?? DateTime.Now;
    }

    public override string ToString() => Date.ToString("dd.MM.yyyy");
}
